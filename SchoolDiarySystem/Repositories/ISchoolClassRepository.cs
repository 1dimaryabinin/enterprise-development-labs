using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с школьными классами.
    /// </summary>
    public class ISchoolClassRepository : IRepository<SchoolClass>
    {
        private readonly SchoolDiaryContext _context;

        public ISchoolClassRepository(SchoolDiaryContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получает все школьные классы.
        /// </summary>
        /// <returns>Список всех школьных классов.</returns>
        public IEnumerable<SchoolClass> GetAll()
        {
            return _context.SchoolClasses.ToList();
        }

        /// <summary>
        /// Получает школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса.</param>
        /// <returns>Школьный класс с заданным идентификатором или null, если не найден.</returns>
        public SchoolClass? GetById(int id)
        {
            return _context.SchoolClasses.Find(id);
        }

        /// <summary>
        /// Добавляет новый школьный класс.
        /// </summary>
        /// <param name="schoolClass">Школьный класс для добавления.</param>
        /// <returns>Идентификатор добавленного школьного класса.</returns>
        public int Post(SchoolClass schoolClass)
        {
            _context.SchoolClasses.Add(schoolClass);
            _context.SaveChanges();
            return schoolClass.ClassId;
        }

        /// <summary>
        /// Обновляет существующий школьный класс.
        /// </summary>
        /// <param name="schoolClass">Школьный класс с обновленными данными.</param>
        /// <returns>True, если класс был успешно обновлен; иначе false.</returns>
        public bool Put(SchoolClass schoolClass)
        {
            var existingClass = _context.SchoolClasses.Find(schoolClass.ClassId);
            if (existingClass == null)
                return false;

            existingClass.Letter = schoolClass.Letter;
            existingClass.Number = schoolClass.Number;
            existingClass.Students = schoolClass.Students;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса для удаления.</param>
        /// <returns>True, если класс был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            var schoolClass = _context.SchoolClasses.Find(id);
            if (schoolClass == null)
                return false;

            _context.SchoolClasses.Remove(schoolClass);
            _context.SaveChanges();
            return true;
        }
    }
}