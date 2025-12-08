using Microsoft.AspNetCore.Mvc;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.BLL.Repository;

namespace HealthRecord1.PL.Controllers
{
    public class ChronicDiseaseController : Controller
    {
        ChronicDiseaseRepo ChronicDisease = new ChronicDiseaseRepo();

        public async Task<IActionResult> Index()
        {
            var data = await ChronicDisease.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChronicDiseaseVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(obj.ICD10Code) && !await ChronicDisease.IsICD10CodeUniqueAsync(obj.ICD10Code))
                    {
                        TempData["ErrorMessage"] = "رمز ICD-10 موجود بالفعل، يرجى التأكد من ان المرض المزمن موجود .";
                        return View(obj);
                    }
                    await ChronicDisease.CreateAsync(obj);
                    TempData["SuccessMessage"] = "تم إضافة المرض المزمن بنجاح!";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "البيانات المدخلة غير صحيحة، يرجى التحقق والمحاولة مرة أخرى.";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء المرض المزمن: " + ex.Message;
                return View(obj);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var chronicDisease = await ChronicDisease.GetByIdAsync(id);
            if (chronicDisease == null)
            {
                return NotFound();
            }
            return View(chronicDisease);
        }

        public async Task<IActionResult> Update(int id)
        {
            var chronicDisease = await ChronicDisease.GetByIdAsync(id);
            if (chronicDisease == null)
            {
                return NotFound();
            }
            return View(chronicDisease);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ChronicDiseaseVM chronicDiseaseVM)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(chronicDiseaseVM.ICD10Code) && !await ChronicDisease.IsICD10CodeUniqueAsync(chronicDiseaseVM.ICD10Code, chronicDiseaseVM.Id))
                {
                    TempData["ErrorMessage"] = "رمز ICD-10 موجود بالفعل، يرجى استخدام رمز آخر.";
                    return View(chronicDiseaseVM);
                }
                await ChronicDisease.UpdateAsync(chronicDiseaseVM);
                TempData["SuccessMessage"] = "تم تحديث المرض المزمن بنجاح!";
                return RedirectToAction("Index");
            }
            return View(chronicDiseaseVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var chronicDisease = await ChronicDisease.GetByIdAsync(id);
            if (chronicDisease == null)
            {
                return NotFound();
            }
            return View(chronicDisease);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await ChronicDisease.DeleteAsync(id);
            TempData["SuccessMessage"] = "تم حذف المرض المزمن بنجاح!";
            return RedirectToAction("Index");
        }
    }
}
