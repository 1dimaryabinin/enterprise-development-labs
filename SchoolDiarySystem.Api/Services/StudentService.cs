using AutoMapper;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;
using SchoolDiarySystem.Domain.Repositories;

namespace SchoolDiarySystem.Api.Services
{
    /// <summary>
    /// Сервис для работы со студентами.
    /// </summary>
    public class StudentService(IMapper _mapper, IRepository<Student> _studentrepository) : IService<StudentGetDto, StudentPostDto>
    {
        /// <summary>
        /// Получает всех студентов.
        /// </summary>
        /// <returns>Список всех студентов в виде <see cref="IEnumerable{StudentGetDto}"/>.</returns>
        public IEnumerable<StudentGetDto> GetAll()
        {
            var students = _studentrepository.GetAll();
            return _mapper.Map<IEnumerable<StudentGetDto>>(students);
        }

        /// <summary>
        /// Получает студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента.</param>
        /// <returns>Студент в виде <see cref="StudentGetDto"/> или null, если не найден.</returns>
        public StudentGetDto? GetById(int id)
        {
            var student = _studentrepository.GetById(id);
            return _mapper.Map<StudentGetDto>(student);
        }

        /// <summary>
        /// Создает нового студента.
        /// </summary>
        /// <param name="postDto">Данные для создания нового студента.</param>
        /// <returns>Идентификатор созданного студента.</returns>
        public int Post(StudentPostDto postDto)
        {
            var student = _mapper.Map<Student>(postDto);
            return _studentrepository.Post(student);
        }

        /// <summary>
        /// Обновляет существующего студента.
        /// </summary>
        /// <param name="id">Идентификатор студента для обновления.</param>
        /// <param name="putDto">Обновленные данные студента.</param>
        /// <returns>Обновленный студент в виде <see cref="StudentGetDto"/> или null, если не найден.</returns>
        public StudentGetDto? Put(int id, StudentPostDto putDto)
        {
            var student = _studentrepository.GetById(id);
            if (student == null)
                return null;

            var updatedStudent = _mapper.Map(putDto, student);
            _studentrepository.Put(updatedStudent);
            return _mapper.Map<StudentGetDto>(updatedStudent);
        }

        /// <summary>
        /// Удаляет студента по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор студента для удаления.</param>
        /// <returns>True, если студент был успешно удален; иначе false.</returns>
        public bool Delete(int id)
        {
            return _studentrepository.Delete(id);
        }
    }
}