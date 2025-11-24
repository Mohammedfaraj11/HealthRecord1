namespace HealthRecord1.BLL.Models;

/// <summary>
/// Represents the association between a patient and a vaccination record, including metadata
/// such as administration details and follow-up information.
/// </summary>
public class VaccinationCardVM
{
    public int Id { get; set; }

    public int PatientId { get; set; } // Foreign key pointing to the patient

    public int VaccinationId { get; set; } // Foreign key pointing to the vaccination

    public DateTime AdministrationDate { get; set; } // Additional details recorded on the vaccination card

    public string? AdministeredBy { get; set; } // Healthcare provider who administered the vaccine

    public string? AdministrationSite { get; set; } // Body site where vaccine was administered

    public string? ReactionNotes { get; set; } // Any reactions or side effects observed

    public DateTime? NextDoseReminder { get; set; } // Reminder date for next dose

    public bool IsCompleted { get; set; } = true; // Whether the vaccination is completed

    public string? AdditionalNotes { get; set; } // Any additional notes
}
