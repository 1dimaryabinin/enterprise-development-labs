namespace SchoolDiarySystem.WebClient.Api;

public class ApiWrapper(IConfiguration configuration) : IApiWrapper
{
    SwaggerGeneratedClient client = new SwaggerGeneratedClient(configuration["ApiUrl"], new HttpClient());

    #region Subject
    public async Task<IEnumerable<SubjectGetDto>> GetAllSubjects() => await client.SubjectAllAsync();
    public async Task<SubjectGetDto> GetSubject(int id) => await client.SubjectGETAsync(id);
    public async Task<SubjectGetDto> AddSubject(SubjectPostDto postDto) => await client.SubjectPOSTAsync(postDto);
    public async Task<SubjectGetDto> UpdateSubject(int id, SubjectPostDto postDto) => await client.SubjectPUTAsync(id, postDto);
    public async Task DeleteSubject(int id) => await client.SubjectDELETEAsync(id);
    #endregion

    #region Student
    public async Task<IEnumerable<StudentGetDto>> GetAllStudents() => await client.StudentAllAsync();
    public async Task<StudentGetDto> GetStudent(int id) => await client.StudentGETAsync(id);
    public async Task<StudentGetDto> AddStudent(StudentPostDto postDto) => await client.StudentPOSTAsync(postDto);
    public async Task<StudentGetDto> UpdateStudent(int id, StudentPostDto postDto) => await client.StudentPUTAsync(id, postDto);
    public async Task DeleteStudent(int id) => await client.StudentDELETEAsync(id);
    #endregion

    #region SchoolClass
    public async Task<IEnumerable<SchoolClassGetDto>> GetAllSchoolClasses() => await client.SchoolClassAllAsync();
    public async Task<SchoolClassGetDto> GetSchoolClass(int id) => await client.SchoolClassGETAsync(id);
    public async Task<SchoolClassGetDto> AddSchoolClass(SchoolClassPostDto postDto) => await client.SchoolClassPOSTAsync(postDto);
    public async Task<SchoolClassGetDto> UpdateSchoolClass(int id, SchoolClassPostDto postDto) => await client.SchoolClassPUTAsync(id, postDto);
    public async Task DeleteSchoolClass(int id) => await client.SchoolClassDELETEAsync(id);
    #endregion

    #region Grade
    public async Task<IEnumerable<GradeGetDto>> GetAllGrades() => await client.GradeAllAsync();
    public async Task<GradeGetDto> GetGrade(int id) => await client.GradeGETAsync(id);
    public async Task<GradeGetDto> AddGrade(GradePostDto postDto) => await client.GradePOSTAsync(postDto);
    public async Task<GradeGetDto> UpdateGrade(int id, GradePostDto postDto) => await client.GradePUTAsync(id, postDto);
    public async Task DeleteGrade(int id) => await client.GradeDELETEAsync(id);
    #endregion
}