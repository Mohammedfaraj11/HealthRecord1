namespace HealthRecord1.BLL.Models;

/// <summary>
/// Represents the association between a patient and a chronic disease, including metadata
/// such as diagnosis details and management plan.
/// </summary>
public class ChronicDiseaseCardVM
{
    public int Id { get; set; }

    public int PatientId { get; set; } // Foreign key pointing to the patient

    public int ChronicDiseaseId { get; set; } // Foreign key pointing to the chronic disease

    public DateTime DiagnosisDate { get; set; } // Additional details recorded on the chronic disease card

    public string? TreatmentPlan { get; set; }

    public string? FollowUpNotes { get; set; }

    public bool IsActive { get; set; } = true;
}
