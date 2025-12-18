using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.BLL.Models;

public class PatientVM
{
    public int Id { get; set; }

    [Required(ErrorMessage = "الرقم الوطني مطلوب")]
    [StringLength(12, MinimumLength = 12, ErrorMessage = "الرقم الوطني يجب أن يتكون من 12 رقم")]
    [RegularExpression(@"^\d{12}$", ErrorMessage = "الرقم الوطني يجب أن يحتوي على أرقام فقط")]
    [Display(Name = "الرقم الوطني")]
    public string NationalId { get; set; } = string.Empty;

    [Required(ErrorMessage = "الاسم الأول مطلوب")]
    [StringLength(100, ErrorMessage = "الاسم الأول يجب ألا يتجاوز 100 حرف")]
    [Display(Name = "الاسم الأول")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "اسم العائلة مطلوب")]
    [StringLength(100, ErrorMessage = "اسم العائلة يجب ألا يتجاوز 100 حرف")]
    [Display(Name = "اسم العائلة")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "تاريخ الميلاد مطلوب")]
    [DataType(DataType.Date)]
    [Display(Name = "تاريخ الميلاد")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "الجنس مطلوب")]
    [StringLength(10)]
    [Display(Name = "الجنس")]
    public string Gender { get; set; } = string.Empty;

    [StringLength(15)]
    [Phone(ErrorMessage = "رقم الهاتف غير صحيح")]
    [Display(Name = "رقم الهاتف")]
    public string? PhoneNumber { get; set; }

    [StringLength(200)]
    [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
    [Display(Name = "البريد الإلكتروني")]
    public string? Email { get; set; }

    [StringLength(500)]
    [Display(Name = "العنوان")]
    public string? Address { get; set; }

    [Display(Name = "تاريخ التسجيل")]
    public DateTime CreationDate { get; set; }

    [Required(ErrorMessage = "فصيلة الدم مطلوبة")]
    [StringLength(5)]
    [Display(Name = "فصيلة الدم")]
    public string? BloodType { get; set; }

    [StringLength(500)]
    [Display(Name = "التاريخ الطبي")]
    public string? MedicalHistory { get; set; }

    [StringLength(500)]
    [Display(Name = "الحساسية")]
    public string? Allergies { get; set; }

    [StringLength(500)]
    [Display(Name = "ملاحظات")]
    public string? Notes { get; set; }

    [StringLength(15)]
    [Phone(ErrorMessage = "رقم الهاتف الثاني غير صحيح")]
    [Display(Name = "رقم الهاتف الثاني")]
    public string? PhoneNumber2 { get; set; }

    [Display(Name = "نشط")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "محذوف")]
    public bool IsDeleted { get; set; } = false;

    [Display(Name = "صورة المريض")]
    public string? ImageName { get; set; }

    public IFormFile? Image { get; set; }

}
