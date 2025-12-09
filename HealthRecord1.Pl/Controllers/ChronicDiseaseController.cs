using AutoMapper;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.BLL.Repository;
using HealthRecord1.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HealthRecord1.PL.Controllers
{
    public class ChronicDiseaseController : Controller
    {
        private readonly IChronicDisease ChronicDisease;
        private readonly IMapper mapper;
        public ChronicDiseaseController(IChronicDisease O, IMapper mapper)
        {
            this.ChronicDisease = O;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await ChronicDisease.GetAllAsync();
            var result = mapper.Map<IEnumerable<ChronicDiseaseVM>>(data);
            return View(result);
        }

        [HttpGet]
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
                    var data = mapper.Map<ChronicDisease>(obj);
                    await ChronicDisease.CreateAsync(data);
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
            var data = await ChronicDisease.GetByIdAsync(id);
            var result = mapper.Map<ChronicDiseaseVM>(data);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var data = await ChronicDisease.GetByIdAsync(id);
            var result = mapper.Map<ChronicDiseaseVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ChronicDiseaseVM obj)
        {
            if (ModelState.IsValid == true)
            {
                var data = mapper.Map<ChronicDisease>(obj);
                await ChronicDisease.UpdateAsync(data);
                TempData["SuccessMessage"] = "تم تحديث المرض المزمن بنجاح!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await ChronicDisease.GetByIdAsync(id);
            var result = mapper.Map<ChronicDiseaseVM>(data);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ChronicDiseaseVM Obj)
        {
            try
            {
                var data = mapper.Map<ChronicDisease>(Obj);
                await ChronicDisease.DeleteAsync(data);
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
