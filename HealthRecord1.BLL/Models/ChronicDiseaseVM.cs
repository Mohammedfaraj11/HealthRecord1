namespace HealthRecord1.BLL.Models;

public class ChronicDiseaseVM
{
    public int Id { get; set; } // Unique identifier for the chronic disease

    public string Name { get; set; } = string.Empty; // Name of the chronic disease

    public DateTime DiagnosisDate { get; set; } // Date of diagnosis

    public string? Description { get; set; } // Description of the disease

    public string? Notes { get; set; } // Additional notes

    public int SeverityScale { get; set; } // Severity level of the disease (1-10 scale)

    public bool IsActive { get; set; } // Indicates if the disease is currently active

    public string? ICD10Code { get; set; } // Standard ICD-10 code for the disease
}
