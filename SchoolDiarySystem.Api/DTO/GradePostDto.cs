namespace SchoolDiarySystem.Api.DTO
{
    public class GradePostDto
    {
        /// <summary>
        /// Значение оценки.
        /// </summary>
        public required int Value { get; set; }

        /// <summary>
        /// Идентификатор ученика, которому выставлена оценка.
        /// </summary>
        public required int StudentId { get; set; }

        /// <summary>
        /// Идентификатор предмета, по которому выставлена оценка.
        /// </summary>
        public required int SubjectId { get; set; }

        /// <summary>
        /// Ссылка на предмет.
        /// </summary>

        public required DateTime Date { get; set; }
    }
}
