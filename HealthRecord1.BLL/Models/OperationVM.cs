namespace HealthRecord1.BLL.Models;

public class OperationVM
{
    public int Id { get; set; } // Unique identifier for the operation

    public string Name { get; set; } = string.Empty; // Name of the operation

    public DateTime Date { get; set; } // Date when the operation was performed

    public DateTime CreationDate { get; set; } // Date when the record was created

    public string? Notes { get; set; } // Additional notes about the operation

    public int Duration { get; set; } // Duration of the operation in minutes

    public string Surgeon { get; set; } = string.Empty; // Name of the surgeon

    public string MedicalTeam { get; set; } = string.Empty; // Details of the medical team

    public int PatientId { get; set; } // Foreign key to Patient
}
