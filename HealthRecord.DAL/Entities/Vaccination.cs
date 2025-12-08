using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.DAL.Entities;

public class Vaccination
{
    [Key]
    public int Id { get; set; } // Unique identifier for the vaccination record

    [Required]
    [MaxLength(200)]
    public string VaccineName { get; set; } = string.Empty; // Name of the vaccine

    [MaxLength(100)]
    public string? Manufacturer { get; set; } // Manufacturer of the vaccine

    public int StandardDoseCount { get; set; } // Standard number of doses required

    [MaxLength(500)]
    public string? Description { get; set; } // Description of the vaccine

    public bool IsActive { get; set; } = true; // Whether the vaccine is currently active in the system

    // Navigation property: vaccination cards linking this patient to vaccination records
    public ICollection<VaccinationCard> VaccinationCards { get; set; } = new List<VaccinationCard>();

}
