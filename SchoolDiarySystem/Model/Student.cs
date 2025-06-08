using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Класс, представляющий ученика.
/// </summary>
[Table("Students")]
public class Student
{
    /// <summary>
    /// Уникальный идентификатор ученика (первичный ключ).
    /// </summary>
    [Key]
    [Column("StudentId")]
    public required int StudentId { get; set; }
    /// <summary>
    /// Паспортные данные ученика.
    /// </summary>
    [Column("Passport")]
    [Required]
    [MaxLength(100)]
    public required string Passport { get; set; }

    /// <summary>
    /// ФИО ученика.
    /// </summary>
    [Column("FullName")]
    [Required]
    [MaxLength(100)]
    public required string FullName { get; set; }

    /// <summary>
    /// Дата рождения ученика.
    /// </summary>
    [Column("BirthDate")]
    [Required]
    [MaxLength(100)]
    public required DateTime BirthDate { get; set; }

    /// <summary>
    /// Идентификатор класса ученика.
    /// </summary>
    [ForeignKey("SchoolClass")]
    [Column("SchoolClassId")]
    public required int ClassId { get; set; }
}
