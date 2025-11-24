using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.DAL.Entities;

public class Patient
{
    [Key]
    public int Id { get; set; } // Unique identifier for the patient

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty; // Patient's first name

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty; // Patient's last name

    [Required]
    public DateTime DateOfBirth { get; set; } // Patient's date of birth

    [Required]
    [MaxLength(10)]
    public string Gender { get; set; } = string.Empty; // Patient's gender (Male/Female/Other)

    [MaxLength(15)]
    public string? PhoneNumber { get; set; } // Patient's phone number

    [MaxLength(200)]
    public string? Email { get; set; } // Patient's email address

    [MaxLength(500)]
    public string? Address { get; set; } // Patient's address

    [Required]
    public DateTime CreationDate { get; set; } // Date when the patient was registered

    [Required]
    [MaxLength(5)]
    public string? BloodType { get; set; } // Patient's blood type (e.g., A+, B-, O+)

    [MaxLength(500)]
    public string? MedicalHistory { get; set; } // Patient's medical history

    [MaxLength(500)]
    public string? Allergies { get; set; } // Patient's known allergies

    [MaxLength(500)]
    public string? Notes { get; set; } // Additional notes about the patient

    [MaxLength(15)]
    public string? PhoneNumber2 { get; set; } // Patient's second phone number

    [Required]
    public bool IsActive { get; set; } // Indicates if the patient record is active

    // Navigation property: chronic disease cards linking this patient to chronic diseases
    public ICollection<ChronicDiseaseCard> ChronicDiseaseCards { get; set; } = new List<ChronicDiseaseCard>();

    // Navigation property: operations performed on this patient
    public ICollection<Operation> Operations { get; set; } = new List<Operation>();

    // Navigation property: vaccination cards linking this patient to vaccination records
    public ICollection<VaccinationCard> VaccinationCards { get; set; } = new List<VaccinationCard>();
}
