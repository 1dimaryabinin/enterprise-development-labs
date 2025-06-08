using SchoolDiarySystem.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SchoolDiarySystem.EfCore
{
    /// <summary>
    /// Фабрика для создания экземпляра контекста SchoolDiaryContext во время выполнения команд EF Core.
    /// </summary>
    public class SchoolDiaryDbContextFactory : IDesignTimeDbContextFactory<SchoolDiaryContext>
    {
        /// <summary>
        /// Создает экземпляр контекста базы данных для использования во время разработки.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>
        /// <returns>Экземпляр контекста SchoolDiaryContext.</returns>
        public SchoolDiaryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolDiaryContext>();

            optionsBuilder.UseMySql(
                "server=localhost; port=3306; uid=root; pwd=sseu1234; database=SchoolDiaryDB",
                new MySqlServerVersion(new Version(8, 0, 2))
            );

            return new SchoolDiaryContext(optionsBuilder.Options);
        }
    }
}