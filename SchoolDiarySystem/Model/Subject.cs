using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Класс, представляющий предмет.
/// </summary>
[Table("Subjects")]
public class Subject
{
    /// <summary>
    /// Уникальный идентификатор предмета (первичный ключ).
    /// </summary>
    [Key]
    [Column("SubjectId")]
    public required int SubjectId { get; set; }

    /// <summary>
    /// Название предмета.
    /// </summary>
    [Column("Name")]
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// Год обучения, в котором преподается предмет.
    /// </summary>
    [Column]
    [Required]
    [MaxLength(50)]
    public required int AcademicYear { get; set; }
}
