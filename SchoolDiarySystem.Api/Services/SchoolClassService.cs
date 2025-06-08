using AutoMapper;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;
using SchoolDiarySystem.Domain.Repositories;


namespace SchoolDiarySystem.Api.Services
{
    /// <summary>
    /// Сервис для работы с школьными классами.
    /// </summary>
    public class SchoolClassService(IMapper _mapper, IRepository<SchoolClass> _schoolclassrepository) : IService<SchoolClassGetDto, SchoolClassPostDto>
    {
        /// <summary>
        /// Получает все школьные классы.
        /// </summary>
        /// <returns>Список всех школьных классов в виде <see cref="IEnumerable{SchoolClassGetDto}"/>.</returns>
        public IEnumerable<SchoolClassGetDto> GetAll()
        {
            var schoolclasses = _schoolclassrepository.GetAll();
            return _mapper.Map<IEnumerable<SchoolClassGetDto>>(schoolclasses);
        }

        /// <summary>
        /// Получает школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса.</param>
        /// <returns>Школьный класс в виде <see cref="SchoolClassGetDto"/> или null, если не найден.</returns>
        public SchoolClassGetDto? GetById(int id)
        {
            var schoolclass = _schoolclassrepository.GetById(id);
            return _mapper.Map<SchoolClassGetDto>(schoolclass);
        }

        /// <summary>
        /// Создает новый школьный класс.
        /// </summary>
        /// <param name="postDto">Данные для создания нового школьного класса.</param>
        /// <returns>Идентификатор созданного школьного класса.</returns>
        public int Post(SchoolClassPostDto postDto)
        {
            var schoolclass = _mapper.Map<SchoolClass>(postDto);
            return _schoolclassrepository.Post(schoolclass);
        }

        /// <summary>
        /// Обновляет существующий школьный класс.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса для обновления.</param>
        /// <param name="putDto">Обновленные данные школьного класса.</param>
        /// <returns>Обновленный школьный класс в виде <see cref="SchoolClassGetDto"/> или null, если не найден.</returns>
        public SchoolClassGetDto? Put(int id, SchoolClassPostDto putDto)
        {
            var schoolclass = _schoolclassrepository.GetById(id);
            if (schoolclass == null)
                return null;

            var updatedSchoolClass = _mapper.Map(putDto, schoolclass);
            _schoolclassrepository.Put(updatedSchoolClass);
            return _mapper.Map<SchoolClassGetDto>(updatedSchoolClass);
        }

        /// <summary>
        /// Удаляет школьный класс по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор школьного класса для удаления.</param>
        /// <returns>True, если школьный класс был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            return _schoolclassrepository.Delete(id);
        }
    }
}
