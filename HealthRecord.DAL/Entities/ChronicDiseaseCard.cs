using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthRecord1.DAL.Entities;

/// <summary>
/// Represents the association between a patient and a chronic disease, including metadata
/// such as diagnosis details and management plan.
/// </summary>
public class ChronicDiseaseCard
{
    [Key]
    public int Id { get; set; }

    // Foreign key pointing to the patient
    [Required]
    public int PatientId { get; set; }

    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;

    // Foreign key pointing to the chronic disease
    [Required]
    public int ChronicDiseaseId { get; set; }

    [ForeignKey(nameof(ChronicDiseaseId))]
    public ChronicDisease ChronicDisease { get; set; } = null!;

    // Additional details recorded on the chronic disease card
    [Required]
    public DateTime DiagnosisDate { get; set; }

    [MaxLength(500)]
    public string? TreatmentPlan { get; set; }

    [MaxLength(500)]
    public string? FollowUpNotes { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;
}