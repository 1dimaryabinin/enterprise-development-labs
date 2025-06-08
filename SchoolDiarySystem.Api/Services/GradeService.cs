using AutoMapper;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;
using SchoolDiarySystem.Domain.Repositories;


namespace SchoolDiarySystem.Api.Services
{
    /// <summary>
    /// Сервис для работы с оценками.
    /// </summary>
    public class GradeService(IMapper _mapper, IRepository<Grade> _graderepository) : IService<GradeGetDto, GradePostDto>
    {
        /// <summary>
        /// Получает все оценки.
        /// </summary>
        /// <returns>Список всех оценок в виде <see cref="IEnumerable{GradeGetDto}"/>.</returns>
        public IEnumerable<GradeGetDto> GetAll()
        {
            var grades = _graderepository.GetAll();
            return _mapper.Map<IEnumerable<GradeGetDto>>(grades);
        }

        /// <summary>
        /// Получает оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки.</param>
        /// <returns>Оценка в виде <see cref="GradeGetDto"/> или null, если не найдена.</returns>
        public GradeGetDto? GetById(int id)
        {
            var grade = _graderepository.GetById(id);
            return _mapper.Map<GradeGetDto>(grade);
        }

        /// <summary>
        /// Создает новую оценку.
        /// </summary>
        /// <param name="postDto">Данные для создания новой оценки.</param>
        /// <returns>Идентификатор созданной оценки.</returns>
        public int Post(GradePostDto postDto)
        {
            var grade = _mapper.Map<Grade>(postDto);
            return _graderepository.Post(grade);
        }

        /// <summary>
        /// Обновляет существующую оценку.
        /// </summary>
        /// <param name="id">Идентификатор оценки для обновления.</param>
        /// <param name="putDto">Обновленные данные оценки.</param>
        /// <returns>Обновленная оценка в виде <see cref="GradeGetDto"/> или null, если не найдена.</returns>
        public GradeGetDto? Put(int id, GradePostDto putDto)
        {
            var grade = _graderepository.GetById(id);
            if (grade == null)
                return null;

            var updatedGrade = _mapper.Map(putDto, grade);
            _graderepository.Put(updatedGrade);
            return _mapper.Map<GradeGetDto>(updatedGrade);
        }

        /// <summary>
        /// Удаляет оценку по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оценки для удаления.</param>
        /// <returns>True, если оценка была успешно удалена; иначе false.</returns>
        public bool Delete(int id)
        {
            return _graderepository.Delete(id);
        }
    }
}
