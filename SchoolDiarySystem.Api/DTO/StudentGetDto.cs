namespace SchoolDiarySystem.Api.DTO
{
    public class StudentGetDto
    {
        public required int StudentId { get; set; }

        public required string Passport { get; set; }

        /// <summary>
        /// ФИО ученика.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Дата рождения ученика.
        /// </summary>
        public required DateTime BirthDate { get; set; }

        /// <summary>
        /// Идентификатор класса ученика.
        /// </summary>
        public required int ClassId { get; set; }
    }
}
