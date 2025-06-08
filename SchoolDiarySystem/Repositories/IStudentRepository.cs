using SchoolDiarySystem.Domain.Model;


namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы со студентами.
    /// </summary>
    public class IStudentRepository : IRepository<Student>
    {
        private readonly SchoolDiaryContext _context;

        public IStudentRepository(SchoolDiaryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает всех студентов.
        /// </summary>
        /// <returns>Список всех студентов.</returns>
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        /// <summary>
        /// Получает студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Студент с заданным идентификатором или null, если не найден.</returns>
        public Student? GetById(int id)
        {
            return _context.Students.Find(id);
        }

        /// <summary>
        /// Добавляет нового студента.
        /// </summary>
        /// <param name="student">Студент для добавления.</param>
        /// <returns>Идентификатор добавленного студента.</returns>
        public int Post(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student.StudentId;
        }

        /// <summary>
        /// Обновляет существующего студента.
        /// </summary>
        /// <param name="student">Студент с обновленными данными.</param>
        /// <returns>True, если студент был успешно обновлен; иначе false.</returns>
        public bool Put(Student student)
        {
            var existingStudent = _context.Students.Find(student.StudentId);
            if (existingStudent == null)
                return false;

            existingStudent.FullName = student.FullName;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Passport = student.Passport;
            existingStudent.ClassId = student.ClassId;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента для удаления.</param>
        /// <returns>True, если студент был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return false;

            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }
    }
}