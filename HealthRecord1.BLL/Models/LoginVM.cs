using System.ComponentModel.DataAnnotations;

namespace HealthRecord1.BLL.Models;

public class LoginVM
{
    [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
    [Display(Name = "البريد الإلكتروني")]
    public string Email { get; set; }

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [DataType(DataType.Password)]
    [Display(Name = "كلمة المرور")]
    public string Password { get; set; }

    [Display(Name = "تذكرني")]
    public bool RememberMe { get; set; }
}
