using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.DAL.Entities;

public class Operation
{
    [Key]
    public int id { get; set; } // Unique identifier for the operation

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty; // Name of the operation

    [Required]
    public DateTime Date { get; set; } // Date when the operation was performed

    [Required]
    public DateTime CreationDate { get; set; } // Date when the record was created

    [MaxLength(500)]
    public string? Notes { get; set; } // Additional notes about the operation

    [Required]
    public int Duration { get; set; } // Duration of the operation in minutes

    [Required]
    [MaxLength(100)]
    public string Surgeon { get; set; } = string.Empty; // Name of the surgeon

    [Required]
    [MaxLength(500)]
    public string MedicalTeam { get; set; } = string.Empty; // Details of the medical team

    // Foreign key for Patient
    [Required]
    public int PatientId { get; set; } // Foreign key to Patient

    // Navigation property to Patient
    public Patient Patient { get; set; } = null!;
}
