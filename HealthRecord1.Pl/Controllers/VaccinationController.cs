using Microsoft.AspNetCore.Mvc;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.BLL.Repository;

namespace HealthRecord1.PL.Controllers
{
    public class VaccinationController : Controller
    {
        VaccinationRepo Vaccination = new VaccinationRepo();

        public async Task<IActionResult> Index()
        {
            var data = await Vaccination.GetAllAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccinationVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Vaccination.CreateAsync(obj);
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "البيانات المدخلة غير صحيحة، يرجى التحقق والمحاولة مرة أخرى.";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء التطعيم: " + ex.Message;
                return View(obj);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var vaccination = await Vaccination.GetByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            return View(vaccination);
        }

        public async Task<IActionResult> Update(int id)
        {
            var vaccination = await Vaccination.GetByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            return View(vaccination);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VaccinationVM vaccinationVM)
        {
            if (ModelState.IsValid)
            {
                await Vaccination.UpdateAsync(vaccinationVM);
                TempData["SuccessMessage"] = "تم تحديث التطعيم بنجاح!";
                return RedirectToAction("Index");
            }
            return View(vaccinationVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var vaccination = await Vaccination.GetByIdAsync(id);
            if (vaccination == null)
            {
                return NotFound();
            }
            return View(vaccination);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Vaccination.DeleteAsync(id);
            TempData["SuccessMessage"] = "تم حذف التطعيم بنجاح!";
            return RedirectToAction("Index");
        }
    }
}
