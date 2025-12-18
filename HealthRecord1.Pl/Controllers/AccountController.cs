using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Extends;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthRecord1.Pl.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
    { 
        this.userManager = userManager;
        this.signInManager = signInManager;
    
    }


    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Registration(RegistrationVM model)
    {
        try
        {
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                IsAgree = model.IsAgree

            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(model);
            }


        }
        catch (Exception ex) {
        return View(model);
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        try
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Account inVaild");
                }
                return View(model);
            }
            ModelState.AddModelError("", "Account inVaild");
            return View(model);
        }
        catch (Exception ex) {
            return View(model);
        }
    }
    public IActionResult Logout()
    {
        // TODO: Add logout logic
        // Clear authentication cookie/session
        TempData["SuccessMessage"] = "تم تسجيل الخروج بنجاح!";
        return RedirectToAction("Index", "Home");
    }
}
