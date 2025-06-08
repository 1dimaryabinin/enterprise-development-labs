namespace SchoolDiarySystem.Api.DTO
{
    public class SubjectPostDto
    {
        /// <summary>
        /// Название предмета.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Год обучения, в котором преподается предмет.
        /// </summary>
        public required int AcademicYear { get; set; }
    }
}
