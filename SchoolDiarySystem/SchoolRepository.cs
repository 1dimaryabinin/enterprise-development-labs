namespace SchoolDiarySystem;
public class SchoolRepository
{
    public List<SchoolClass> Classes { get; set; } = new();
    public List<Student> Students { get; set; } = new();
    public List<Subject> Subjects { get; set; } = new();
    public List<Grade> Grades { get; set; } = new();

    public List<Student> GetStudentsByClass(int classId)
    {
        return Students.Where(s => s.ClassId == classId).OrderBy(s => s.FullName).ToList();
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }

    public List<Grade> GetGradesByStudentAndSubject(int studentId, int subjectId)
    {
        return Grades.Where(g => g.StudentId == studentId && g.SubjectId == subjectId).ToList();
    }

    public void AddGrade(Grade grade)
    {
        Grades.Add(grade);
    }

    public double GetAverageGradeForClassAndSubject(int classId, int subjectId)
    {
        var studentIds = Students.Where(s => s.ClassId == classId).Select(s => s.StudentId);
        return Grades.Where(g => studentIds.Contains(g.StudentId) && g.SubjectId == subjectId)
                     .Average(g => g.Value);
    }

    public List<Subject> GetAllSubjects()
    {
        return Subjects.ToList();
    }

    public List<Student> GetStudentsByGradesOnDate(DateTime date)
    {
        var studentIds = Grades.Where(g => g.Date.Date == date.Date).Select(g => g.StudentId).Distinct();
        return Students.Where(s => studentIds.Contains(s.StudentId)).ToList();
    }

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