using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.BLL.Models;

public class RegistrationVM
{
    [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
    [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صحيح")]
    [Display(Name = "البريد الإلكتروني")]
    public string Email { get; set; }

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "كلمة المرور يجب أن تكون على الأقل 6 أحرف")]
    [DataType(DataType.Password)]
    [Display(Name = "كلمة المرور")]
    public string Password { get; set; }

    [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "كلمة المرور وتأكيدها غير متطابقين")]
    [Display(Name = "تأكيد كلمة المرور")]
    public string ConfirmPassword { get; set; }

    [Display(Name = "الموافقة على الشروط والأحكام")]
    [MustBeTrue(ErrorMessage = "يجب الموافقة على الشروط والأحكام")]
    public bool IsAgree { get; set; }
}

// Custom Validation Attribute
public class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return value is bool b && b;
    }
}
