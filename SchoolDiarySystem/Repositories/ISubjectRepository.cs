using SchoolDiarySystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDiarySystem.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для работы с предметами.
    /// </summary>
    public class ISubjectRepository : IRepository<Subject>
    {
        private readonly SchoolDiaryContext _context;

        public ISubjectRepository(SchoolDiaryContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Получает все предметы.
        /// </summary>
        /// <returns>Список всех предметов.</returns>
        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }

        /// <summary>
        /// Получает предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета.</param>
        /// <returns>Предмет с заданным идентификатором или null, если не найден.</returns>
        public Subject? GetById(int id)
        {
            return _context.Subjects.Find(id);
        }

        /// <summary>
        /// Добавляет новый предмет.
        /// </summary>
        /// <param name="subject">Предмет для добавления.</param>
        /// <returns>Идентификатор добавленного предмета.</returns>
        public int Post(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return subject.SubjectId;
        }

        /// <summary>
        /// Обновляет существующий предмет.
        /// </summary>
        /// <param name="subject">Предмет с обновленными данными.</param>
        /// <returns>True, если предмет был успешно обновлен; иначе false.</returns>
        public bool Put(Subject subject)
        {
            var existingSubject = _context.Subjects.Find(subject.SubjectId);
            if (existingSubject == null)
                return false;

            existingSubject.Name = subject.Name;
            existingSubject.AcademicYear = subject.AcademicYear;

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Удаляет предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета для удаления.</param>
        /// <returns>True, если предмет был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null)
                return false;

            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return true;
        }
    }
}