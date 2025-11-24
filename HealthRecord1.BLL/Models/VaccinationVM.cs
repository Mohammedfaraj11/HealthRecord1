namespace HealthRecord1.BLL.Models;

public class VaccinationVM
{
    public int Id { get; set; } // Unique identifier for the vaccination record

    public string VaccineName { get; set; } = string.Empty; // Name of the vaccine administered

    public DateTime DateAdministered { get; set; } // Date when the vaccine was administered

    public int? DoseNumber { get; set; } // Dose number in the vaccination series (e.g., 1st, 2nd, booster)

    public string? BatchNumber { get; set; } // Batch or lot number of the vaccine

    public string? Manufacturer { get; set; } // Manufacturer of the vaccine

    public DateTime? NextDoseDate { get; set; } // Date for the next dose if applicable

    public string? Notes { get; set; } // Additional notes about the vaccination
}
