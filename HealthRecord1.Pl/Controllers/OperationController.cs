using Microsoft.AspNetCore.Mvc;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.BLL.Repository;

namespace HealthRecord1.PL.Controllers
{
    public class OperationController : Controller
    {
        OperationRepo Operation = new OperationRepo();

        public async Task<IActionResult> Index()
        {
            var data = await Operation.GetAllAsync();
            return View(data);
        }

        [HttpGet] // data (PL Operation VM) ==> BLL ==> DAL ==> cshtml
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // data (PL Operation VM) ==> BLL ==> DAL ==> cshtml
        public async Task<IActionResult> Create(OperationVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.CreationDate = DateTime.Now;
                    await Operation.CreateAsync(obj);
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "البيانات المدخلة غير صحيحة، يرجى التحقق والمحاولة مرة أخرى.";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء العملية: " + ex.Message;
                return View(obj);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var operation = await Operation.GetByIdAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            return View(operation);
        }

        public async Task<IActionResult> Update(int id)
        {
            var operation = await Operation.GetByIdAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            return View(operation);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OperationVM operationVM)
        {
            if (ModelState.IsValid)
            {
                await Operation.UpdateAsync(operationVM);
                TempData["SuccessMessage"] = "تم تحديث العملية بنجاح!";
                return RedirectToAction("Index");
            }
            return View(operationVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var operation = await Operation.GetByIdAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            return View(operation);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await Operation.DeleteAsync(id);
            TempData["SuccessMessage"] = "تم حذف العملية بنجاح!";
            return RedirectToAction("Index");
        }
    }
}
