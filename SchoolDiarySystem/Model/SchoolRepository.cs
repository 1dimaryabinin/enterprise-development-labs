namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Репозиторий для работы с классами, учениками, предметами и оценками.
/// </summary>
public class SchoolRepository
{
    public List<SchoolClass> Classes { get; set; } = new();
    public List<Student> Students { get; set; } = new();
    public List<Subject> Subjects { get; set; } = new();
    public List<Grade> Grades { get; set; } = new();

    /// <summary>
    /// Получить список всех учеников указанного класса, список упорядочен по ФИО
    /// </summary>
    public List<Student> GetStudentsByClass(int classId) =>
         Students.Where(s => s.ClassId == classId).OrderBy(s => s.FullName).ToList();


    /// <summary>
    /// Добавить нового ученика в систему.
    /// </summary>
    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    /// <summary>
    /// Получить оценки ученика по указанному предмету.
    /// </summary>
    public List<Grade> GetGradesByStudentAndSubject(int studentId, int subjectId) =>
         Grades.Where(g => g.StudentId == studentId && g.SubjectId == subjectId).ToList();


    /// <summary>
    /// Добавить новую оценку в систему.
    /// </summary>
    public void AddGrade(Grade grade)
    {
        Grades.Add(grade);
    }

    /// <summary>
    /// Получить среднюю оценку по предмету для всего класса.
    /// </summary>
    public double GetAverageGradeForClassAndSubject(int classId, int subjectId)
    {
        var studentIds = Students.Where(s => s.ClassId == classId).Select(s => s.StudentId);
        return Grades.Where(g => studentIds.Contains(g.StudentId) && g.SubjectId == subjectId)
                     .Average(g => g.Value);
    }

    /// <summary>
    /// Вывести информацию обо всех предметах.
    /// </summary>
    public List<Subject> GetAllSubjects() =>
      Subjects.ToList();



    /// <summary>
    /// Вывести информацию обо всех учениках, получивших оценки в указанный день.
    /// </summary>
    public List<Student> GetStudentsByGradesOnDate(DateTime date)
    {
        var studentIds = Grades.Where(g => g.Date.Date == date.Date).Select(g => g.StudentId).Distinct();
        return Students.Where(s => studentIds.Contains(s.StudentId)).ToList();
    }

    /// <summary>
    /// Вывести топ 5 учеников по среднему баллу.
    /// </summary>
    public List<(Student Student, double AverageGrade)> GetTop5StudentsByAverageGrade()
    {
        return Students.Select(s => new
        {
            Student = s,
            AverageGrade = Grades.Where(g => g.StudentId == s.StudentId).Average(g => (double?)g.Value) ?? 0
        })
               .OrderByDescending(x => x.AverageGrade)
               .Take(5)
               .Select(x => (x.Student, x.AverageGrade))
               .ToList();
    }

    /// <summary>
    /// Вывести учеников с максимальным средним баллом за указанный период.
    /// </summary>
    public List<(Student Student, double AverageGrade)> GetStudentsWithMaxAverageGrade(DateTime startDate, DateTime endDate)
    {
        var filteredGrades = Grades.Where(g => g.Date.Date >= startDate.Date && g.Date.Date <= endDate.Date);

        var studentAverages = Students.Select(s => new
        {
            Student = s,
            AverageGrade = filteredGrades.Where(g => g.StudentId == s.StudentId).Average(g => (double?)g.Value) ?? 0
        });

        var maxAverage = studentAverages.Max(x => x.AverageGrade);
        return studentAverages.Where(x => x.AverageGrade == maxAverage)
                              .Select(x => (x.Student, x.AverageGrade))
                              .ToList();
    }

    /// <summary>
    /// Вывести информацию о минимальном, среднем и максимальном балле по каждому предмету.
    /// </summary>
    public List<(Subject Subject, double MinGrade, double AvgGrade, double MaxGrade)> GetGradeStatisticsBySubject()
    {
        return Subjects.Select(subject =>
        {
            var subjectGrades = Grades.Where(g => g.SubjectId == subject.SubjectId);
            return (
                Subject: subject,
                MinGrade: subjectGrades.Min(g => (double?)g.Value) ?? 0,
                AvgGrade: subjectGrades.Average(g => (double?)g.Value) ?? 0,
                MaxGrade: subjectGrades.Max(g => (double?)g.Value) ?? 0
            );
        }).ToList();
    }
}
