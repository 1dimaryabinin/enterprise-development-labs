using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с оценками.
    /// </summary>
    public class IGradeRepository : IRepository<Grade>
    {
        private readonly SchoolDiaryContext _context;
        public IGradeRepository(SchoolDiaryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Получает все оценки.
        /// </summary>
        /// <returns>Список всех оценок.</returns>
        public IEnumerable<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        /// <summary>
        /// Получает оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки.</param>
        /// <returns>Оценка с заданным идентификатором или null, если не найдена.</returns>
        public Grade? GetById(int id)
        {
            return _context.Grades.Find(id);
        }

        /// <summary>
        /// Добавляет новую оценку.
        /// </summary>
        /// <param name="grade">Оценка для добавления.</param>
        /// <returns>Идентификатор добавленной оценки.</returns>
        public int Post(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return grade.GradeId;
        }

        /// <summary>
        /// Обновляет существующую оценку.
        /// </summary>
        /// <param name="grade">Оценка с обновленными данными.</param>
        /// <returns>True, если оценка была успешно обновлена; иначе false.</returns>
        public bool Put(Grade grade)
        {
            var existingGrade = _context.Grades.Find(grade.GradeId);
            if (existingGrade == null)
                return false;

            existingGrade.Value = grade.Value;
            existingGrade.SubjectId = grade.SubjectId;
            existingGrade.StudentId = grade.StudentId;
            existingGrade.Date = grade.Date;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки для удаления.</param>
        /// <returns>True, если оценка была успешно удалена; иначе false.</returns>
        public bool Delete(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade == null)
                return false;

            _context.Grades.Remove(grade);
            _context.SaveChanges();
            return true;
        }
    }
}