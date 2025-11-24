using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthRecord1.DAL.Entities;

/// <summary>
/// Represents the association between a patient and a vaccination record, including metadata
/// such as administration details and follow-up information.
/// </summary>
public class VaccinationCard
{
    [Key]
    public int Id { get; set; }

    // Foreign key pointing to the patient
    [Required]
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

    // Foreign key pointing to the vaccination
    [Required]
    public int VaccinationId { get; set; }

    [ForeignKey(nameof(VaccinationId))]
    public Vaccination Vaccination { get; set; } = null!;

    // Additional details recorded on the vaccination card
    [Required]
    public DateTime AdministrationDate { get; set; }

    [MaxLength(100)]
    public string? AdministeredBy { get; set; } // Healthcare provider who administered the vaccine

    [MaxLength(50)]
    public string? AdministrationSite { get; set; } // Body site where vaccine was administered

    [MaxLength(500)]
    public string? ReactionNotes { get; set; } // Any reactions or side effects observed

    public DateTime? NextDoseReminder { get; set; } // Reminder date for next dose

    [Required]
    public bool IsCompleted { get; set; } = true; // Whether the vaccination is completed

    [MaxLength(500)]
    public string? AdditionalNotes { get; set; } // Any additional notes
}
