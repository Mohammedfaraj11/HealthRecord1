using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.DAL.Entities;

public class ChronicDisease
{
    [Key]
    public int Id { get; set; } // Unique identifier for the chronic disease

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty; // Name of the chronic disease

    [Required]
    public DateTime DiagnosisDate { get; set; } // Date of diagnosis

    [MaxLength(500)]
    public string? Description { get; set; } // Description of the disease

    [MaxLength(500)]
    public string? Notes { get; set; } // Additional notes

    [Required]
    public int SeverityScale { get; set; } // Severity level of the disease (1-10 scale)

    [Required]
    public bool IsActive { get; set; } // Indicates if the disease is currently active

    [MaxLength(10)]
    public string? ICD10Code { get; set; } // Standard ICD-10 code for the disease

    // Navigation property: chronic disease cards linking this disease to patients
    public ICollection<ChronicDiseaseCard> ChronicDiseaseCards { get; set; } = new List<ChronicDiseaseCard>();
}