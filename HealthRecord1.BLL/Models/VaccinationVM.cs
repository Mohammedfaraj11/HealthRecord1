namespace HealthRecord1.BLL.Models;

public class VaccinationVM
{
    public int Id { get; set; } // Unique identifier for the vaccination record

    public string VaccineName { get; set; } = string.Empty; // Name of the vaccine

    public string? Manufacturer { get; set; } // Manufacturer of the vaccine

    public int StandardDoseCount { get; set; } // Standard number of doses required

    public string? Description { get; set; } // Description of the vaccine

    public bool IsActive { get; set; } // Whether the vaccine is currently active
}
