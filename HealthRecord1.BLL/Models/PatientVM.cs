namespace HealthRecord1.BLL.Models;

public class PatientVM
{
    public int Id { get; set; } // Unique identifier for the patient

    public string FirstName { get; set; } = string.Empty; // Patient's first name

    public string LastName { get; set; } = string.Empty; // Patient's last name

    public DateTime DateOfBirth { get; set; } // Patient's date of birth

    public string Gender { get; set; } = string.Empty; // Patient's gender (Male/Female/Other)

    public string? PhoneNumber { get; set; } // Patient's phone number

    public string? Email { get; set; } // Patient's email address

    public string? Address { get; set; } // Patient's address

    public DateTime CreationDate { get; set; } // Date when the patient was registered

    public string? BloodType { get; set; } // Patient's blood type (e.g., A+, B-, O+)

    public string? MedicalHistory { get; set; } // Patient's medical history

    public string? Allergies { get; set; } // Patient's known allergies

    public string? Notes { get; set; } // Additional notes about the patient

    public string? PhoneNumber2 { get; set; } // Patient's second phone number

    public bool IsActive { get; set; } // Indicates if the patient record is active
}
