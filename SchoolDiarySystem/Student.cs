namespace SchoolDiarySystem;
public class Student
{
    public int StudentId { get; set; }

    public required string Passport { get; set; }

    public required string FullName { get; set; }

    public required DateTime BirthDate { get; set; }

    public int ClassId { get; set; }
}
