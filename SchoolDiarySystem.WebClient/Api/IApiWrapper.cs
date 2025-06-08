namespace SchoolDiarySystem.WebClient.Api;

public interface IApiWrapper
{
    Task<StudentGetDto> AddStudent(StudentPostDto postDto);
    Task<SubjectGetDto> AddSubject(SubjectPostDto postDto);
    Task DeleteStudent(int id);
    Task DeleteSubject(int id);
    Task<IEnumerable<StudentGetDto>> GetAllStudents();
    Task<IEnumerable<SubjectGetDto>> GetAllSubjects();
    Task<IEnumerable<SchoolClassGetDto>> GetAllSchoolClasses();
    Task<StudentGetDto> GetStudent(int id);
    Task<SubjectGetDto> GetSubject(int id);
    Task<StudentGetDto> UpdateStudent(int id, StudentPostDto postDto);
    Task<SubjectGetDto> UpdateSubject(int id, SubjectPostDto postDto);
}