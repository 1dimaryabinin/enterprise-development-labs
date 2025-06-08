using SchoolDiarySystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SchoolDiarySystem.Domain
{
    public class SchoolDiaryContext : DbContext
    {
        public SchoolDiaryContext(DbContextOptions<SchoolDiaryContext> options) : base (options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка отношений для Student и SchoolClass
            modelBuilder.Entity<Student>()
                .HasOne<SchoolClass>() 
                .WithMany(sc => sc.Students) 
                .HasForeignKey(s => s.ClassId); 

            // Настройка отношений для Grade и Student
            modelBuilder.Entity<Grade>()
                .HasOne<Student>() 
                .WithMany() 
                .HasForeignKey(g => g.StudentId);

            // Настройка отношений для Grade и Subject
            modelBuilder.Entity<Grade>()
                .HasOne<Subject>() 
                .WithMany() 
                .HasForeignKey(g => g.SubjectId); 
        }

    }
}
