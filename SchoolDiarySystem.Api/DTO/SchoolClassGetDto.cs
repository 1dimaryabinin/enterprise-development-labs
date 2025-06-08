using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Api.DTO
{
    public class SchoolClassGetDto
    {
        /// <summary>
        /// Уникальный идентификатор ученика (первичный ключ).
        /// </summary>
        public required int StudentId { get; set; }

        /// <summary>
        /// Уникальный идентификатор класса (первичный ключ).
        /// </summary>
        public required int ClassId { get; set; }

        /// <summary>
        /// Номер класса (например, 10).
        /// </summary>
        public required int Number { get; set; }

        /// <summary>
        /// Литера класса (например, "А").
        /// </summary>
        public required string Letter { get; set; }

        /// <summary>
        /// Список учеников в классе.
        /// </summary>
        public List<Student> Students { get; set; } = new();
    }
}
