namespace SchoolDiarySystem;
public class SchoolClass
{
    public int ClassId { get; set; }

    public required int Number { get; set; }

    public required string Letter { get; set; }

    public List<Student> Students { get; set; } = new();
}
