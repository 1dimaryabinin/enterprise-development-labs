using System.Reflection;
using SchoolDiarySystem.Api;
using SchoolDiarySystem.Api.Services;
using SchoolDiarySystem.Api.DTO;
using SchoolDiarySystem.Domain.Model;
using SchoolDiarySystem.Domain.Repositories;
using SchoolDiarySystem.Tests;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SchoolDiarySystem.Domain;

var builder = WebApplication.CreateBuilder(args);

//var ConnectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<SchoolDiaryContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 2))));

//создание образа SchoolFixture

var SchoolFixture = new SchoolFixture();

//регистрация контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//регистрация репозиториев
builder.Services.AddScoped<IRepository<Student>, IStudentRepository>();
builder.Services.AddScoped<IRepository<SchoolClass>, ISchoolClassRepository>();
builder.Services.AddScoped<IRepository<Subject>, ISubjectRepository>();
builder.Services.AddScoped<IRepository<Grade>, IGradeRepository>();


//регистрация сервисов и интерфейсов
builder.Services.AddScoped<IService<StudentGetDto, StudentPostDto>, StudentService>();
builder.Services.AddScoped<IService<SchoolClassGetDto, SchoolClassPostDto>, SchoolClassService>();
builder.Services.AddScoped<IService<GradeGetDto, GradePostDto>, GradeService>();
builder.Services.AddScoped<IService<SubjectGetDto, SubjectPostDto>, SubjectService>();

//регистрация AutoMapper
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => {
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
