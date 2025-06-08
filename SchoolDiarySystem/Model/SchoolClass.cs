using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Класс, представляющий класс учащихся.
/// </summary>
[Table("SchoolClasses")]
public class SchoolClass
{
    /// <summary>
    /// Уникальный идентификатор класса (первичный ключ).
    /// </summary>
    [Key]
    [Column("SchoolClassId")]
    public required int ClassId { get; set; }

    /// <summary>
    /// Номер класса (например, 10).
    /// </summary>
    [Column("Number")]
    [Required]
    [MaxLength(50)]
    public required int Number { get; set; }

    /// <summary>
    /// Литера класса (например, "А").
    /// </summary>
    [Column("Letter")]
    [Required]
    [MaxLength(50)]
    public required string Letter { get; set; }

    /// <summary>
    /// Список учеников в классе.
    /// </summary>
    public List<Student> Students { get; set; } = new();
}
