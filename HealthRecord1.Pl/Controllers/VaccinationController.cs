using AutoMapper;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.BLL.Repository;
using HealthRecord1.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthRecord1.PL.Controllers
{
    [Authorize]
    public class VaccinationController : Controller
    {
        private readonly IVaccination Vaccination;
        private readonly IMapper mapper;
        public VaccinationController(IVaccination O, IMapper mapper)
        {
            this.Vaccination = O;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await Vaccination.GetAllAsync();
            var result = mapper.Map<IEnumerable<VaccinationVM>>(data);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new VaccinationVM 
            { 
                StandardDoseCount = 1,
                IsActive = true 
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccinationVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Vaccination>(obj);
                    await Vaccination.CreateAsync(data);
                    TempData["SuccessMessage"] = "تم إضافة التطعيم بنجاح!";
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
            var data = await Vaccination.GetByIdAsync(id);
            var result = mapper.Map<VaccinationVM>(data);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var data = await Vaccination.GetByIdAsync(id);
            var result = mapper.Map<VaccinationVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(VaccinationVM obj)
        {
            if (ModelState.IsValid == true)
            {
                var data = mapper.Map<Vaccination>(obj);
                await Vaccination.UpdateAsync(data);
                TempData["SuccessMessage"] = "تم تحديث التطعيم بنجاح!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Vaccination.GetByIdAsync(id);
            var result = mapper.Map<VaccinationVM>(data);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(VaccinationVM Obj)
        {
            try
            {
                var data = mapper.Map<Vaccination>(Obj);
                await Vaccination.DeleteAsync(data);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(Obj);
            }
        }
    }
}
