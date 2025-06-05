namespace SchoolDiarySystem;

public class Grade
{
    public int GradeId { get; set; }

    public required int Value { get; set; }

    public int StudentId { get; set; }

    public int SubjectId { get; set; }

    public required DateTime Date { get; set; }
}
