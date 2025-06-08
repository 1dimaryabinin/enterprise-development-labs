using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDiarySystem.Domain.Model;

/// <summary>
/// Класс, представляющий оценку.
/// </summary>
[Table("Grades")]
public class Grade
{
    /// <summary>
    /// Уникальный идентификатор оценки (первичный ключ).
    /// </summary>
    [Key]
    [Column("GradeId")]
    public required int GradeId { get; set; }

    /// <summary>
    /// Значение оценки.
    /// </summary>
    [Column("Value")]
    [Required]
    [MaxLength(2)]
    public required int Value { get; set; }

    /// <summary>
    /// Идентификатор ученика, которому выставлена оценка.
    /// </summary>
    [ForeignKey("Student")]
    [Column("StudentId")]
    [Required]
    public required int StudentId { get; set; }

    /// <summary>
    /// Идентификатор предмета, по которому выставлена оценка.
    /// </summary>
    [ForeignKey("Subject")]
    [Column("Subject_Id")]
    [Required]
    public required int SubjectId { get; set; }

    /// <summary>
    /// Ссылка на предмет.
    /// </summary>
    [Column("Date")]
    [Required]
    public required DateTime Date { get; set; }
}
