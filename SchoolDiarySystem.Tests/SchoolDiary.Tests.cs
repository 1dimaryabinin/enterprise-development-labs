using System;
using System.Linq;
using Xunit;
using SchoolDiarySystem.Domain.Model;

namespace SchoolDiarySystem.Tests
{
    /// <summary>
    /// Класс тестов для SchoolRepository с использованием фикстуры данных
    /// </summary>
    public class SchoolRepositoryTests : IClassFixture<SchoolFixture>
    {
        private readonly SchoolRepository _repository;

        /// <summary>
        /// Инициализация тестов с использованием SchoolFixture
        /// </summary>
        public SchoolRepositoryTests(SchoolFixture fixture)
        {
            _repository = fixture.Repository;
        }

        /// <summary>
        /// Тест для вывода информации обо всех предметах
        /// </summary>
        [Fact]
        public void Test_GetAllSubjects()
        {
            // Act
            var subjects = _repository.GetAllSubjects();

            // Assert
            Assert.NotEmpty(subjects);
            Assert.Equal(4, subjects.Count); // Ожидается 4 предмета
        }

        /// <summary>
        /// Тест для вывода информации обо всех учениках в указанном классе
        /// </summary>
        [Fact]
        public void Test_GetStudentsByClass()
        {
            // Act
            var students = _repository.GetStudentsByClass(1);

            // Assert
            Assert.NotEmpty(students);
            Assert.Equal(5, students.Count); // Ожидается 5 учеников в классе 10А
        }

        /// <summary>
        /// Тест для вывода информации обо всех учениках, получивших оценки в указанный день
        /// </summary>
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

        /// <summary>
        /// Тест для вывода топ-5 учеников по среднему баллу
        /// </summary>
        [Fact]
        public void Test_GetTop5StudentsByAverageGrade()
        {
            // Act
            var topStudents = _repository.GetTop5StudentsByAverageGrade();

            // Assert
            Assert.NotEmpty(topStudents);
            Assert.True(topStudents.Count <= 5, "Результат должен содержать не более 5 учеников.");
        }

        /// <summary>
        /// Тест для вывода учеников с максимальным средним баллом за указанный период
        /// </summary>
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

        /// <summary>
        /// Тест для вывода информации о минимальном, среднем и максимальном балле по каждому предмету
        /// </summary>
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
