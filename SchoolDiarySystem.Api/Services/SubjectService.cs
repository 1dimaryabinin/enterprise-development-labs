using AutoMapper;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;
using SchoolDiarySystem.Domain.Repositories;

namespace SchoolDiarySystem.Api.Services
{
    /// <summary>
    /// Сервис для работы с предметами.
    /// </summary>
    public class SubjectService(IMapper _mapper, IRepository<Subject> _subjectrepository) : IService<SubjectGetDto, SubjectPostDto>
    {
        /// <summary>
        /// Получает все предметы.
        /// </summary>
        /// <returns>Список всех предметов в виде <see cref="IEnumerable{SubjectGetDto}"/>.</returns>
        public IEnumerable<SubjectGetDto> GetAll()
        {
            var subjects = _subjectrepository.GetAll();
            return _mapper.Map<IEnumerable<SubjectGetDto>>(subjects);
        }

        /// <summary>
        /// Получает предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета.</param>
        /// <returns>Предмет в виде <see cref="SubjectGetDto"/> или null, если не найден.</returns>
        public SubjectGetDto? GetById(int id)
        {
            var subject = _subjectrepository.GetById(id);
            return _mapper.Map<SubjectGetDto>(subject);
        }

        /// <summary>
        /// Создает новый предмет.
        /// </summary>
        /// <param name="postDto">Данные для создания нового предмета.</param>
        /// <returns>Идентификатор созданного предмета.</returns>
        public int Post(SubjectPostDto postDto)
        {
            var subject = _mapper.Map<Subject>(postDto);
            return _subjectrepository.Post(subject);
        }

        /// <summary>
        /// Обновляет существующий предмет.
        /// </summary>
        /// <param name="id">Идентификатор предмета для обновления.</param>
        /// <param name="putDto">Обновленные данные предмета.</param>
        /// <returns>Обновленный предмет в виде <see cref="SubjectGetDto"/> или null, если не найден.</returns>
        public SubjectGetDto? Put(int id, SubjectPostDto putDto)
        {
            var subject = _subjectrepository.GetById(id);
            if (subject == null)
                return null;

            var updatedSubject = _mapper.Map(putDto, subject);
            _subjectrepository.Put(updatedSubject);
            return _mapper.Map<SubjectGetDto>(updatedSubject);
        }

        /// <summary>
        /// Удаляет предмет по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор предмета для удаления.</param>
        /// <returns>True, если предмет был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            return _subjectrepository.Delete(id);
        }
    }
}