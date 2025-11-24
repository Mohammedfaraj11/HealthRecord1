using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.DAL.Entities;

public class Vaccination
{
    [Key]
    public int Id { get; set; } // Unique identifier for the vaccination record

    [Required]
    [MaxLength(200)]
    public string VaccineName { get; set; } = string.Empty; // Name of the vaccine administered

    [Required]
    public DateTime DateAdministered { get; set; } // Date when the vaccine was administered

    public int? DoseNumber { get; set; } // Dose number in the vaccination series (e.g., 1st, 2nd, booster)

    [MaxLength(50)]
    public string? BatchNumber { get; set; } // Batch or lot number of the vaccine

    [MaxLength(100)]
    public string? Manufacturer { get; set; } // Manufacturer of the vaccine

    public DateTime? NextDoseDate { get; set; } // Date for the next dose if applicable

    [MaxLength(500)]
    public string? Notes { get; set; } // Additional notes about the vaccination

    // Navigation property: vaccination cards linking this patient to vaccination records
    public ICollection<VaccinationCard> VaccinationCards { get; set; } = new List<VaccinationCard>();


}
