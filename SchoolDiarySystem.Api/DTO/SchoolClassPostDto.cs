using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Api.DTO
{
    public class SchoolClassPostDto
    {
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
