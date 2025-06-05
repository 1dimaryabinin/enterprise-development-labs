using System;
using System.Linq;
using Xunit;
using SchoolDiarySystem;

namespace Tests
{
    public class SchoolRepositoryTests : IClassFixture<SchoolFixture>
    {
        private readonly SchoolRepository _repository;
        public SchoolRepositoryTests(SchoolFixture fixture)
        {
            _repository = fixture.Repository;
        }
        [Fact]
        public void Test_GetAllSubjects()
        {
            // Act
            var subjects = _repository.GetAllSubjects();

            // Assert
            Assert.NotEmpty(subjects);
            Assert.Equal(4, subjects.Count); // Ожидается 4 предмета
        }

        [Fact]
        public void Test_GetStudentsByClass()
        {
            // Act
            var students = _repository.GetStudentsByClass(1);

            // Assert
            Assert.NotEmpty(students);
            Assert.Equal(5, students.Count); // Ожидается 5 учеников в классе 10А
        }

        [Fact]
        public void Test_GetStudentsWithGradesOnDate()
        {
            // Arrange
            var date = DateTime.Now.Date;

            // Act
            var students = _repository.GetStudentsByGradesOnDate(date);

            // Assert
            Assert.NotEmpty(students);
            Assert.Contains(students, s => s.FullName == "Иванов Иван Иванович");
        }

        [Fact]
        public void Test_GetTop5StudentsByAverageGrade()
        {
            // Act
            var topStudents = _repository.GetTop5StudentsByAverageGrade();

            // Assert
            Assert.NotEmpty(topStudents);
            Assert.True(topStudents.Count <= 5, "Результат должен содержать не более 5 учеников.");
        }

        [Fact]
        public void Test_GetStudentsWithMaxAverageGrade()
        {
            // Arrange
            var startDate = DateTime.Now.AddMonths(-1);
            var endDate = DateTime.Now;

            // Act
            var students = _repository.GetStudentsWithMaxAverageGrade(startDate, endDate);

            // Assert
            Assert.NotEmpty(students);
            Assert.Contains(students, s => s.Student.FullName == "Петров Петр Петрович");
        }

        [Fact]
        public void Test_GetGradeStatisticsBySubject()
        {
            // Act
            var statistics = _repository.GetGradeStatisticsBySubject();

            // Assert
            Assert.NotEmpty(statistics);

            // Проверка на наличие всех предметов в статистике
            Assert.Contains(statistics, s => s.Subject.Name == "Математика");
            Assert.Contains(statistics, s => s.Subject.Name == "Физика");
            Assert.Contains(statistics, s => s.Subject.Name == "История");
            Assert.Contains(statistics, s => s.Subject.Name == "География");

            // Проверка диапазона оценок
            var mathStats = statistics.FirstOrDefault(s => s.Subject.Name == "Математика");
            Assert.True(mathStats.MaxGrade >= mathStats.MinGrade, "Максимальная оценка должна быть больше или равна минимальной.");
        }
    }
}