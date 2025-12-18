using AutoMapper;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.BLL.Repository;
using HealthRecord1.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HealthRecord1.PL.Controllers
{
    [Authorize]
    public class OperationController : Controller
    {
        private readonly IOperation Operation;
        private readonly IMapper mapper;
        public OperationController(IOperation O, IMapper mapper)
        {
            this.Operation = O;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await Operation.GetAllAsync();
            var result = mapper.Map<IEnumerable<OperationVM>>(data);
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new OperationVM 
            { 
                Date = DateTime.Now,
                CreationDate = DateTime.Now,
                Duration = 60 // Default 1 hour
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OperationVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Operation>(obj);
                    await Operation.CreateAsync(data);
                    TempData["SuccessMessage"] = "تم إضافة العملية الجراحية بنجاح!";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "البيانات المدخلة غير صحيحة، يرجى التحقق والمحاولة مرة أخرى.";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء إنشاء العملية الجراحية: " + ex.Message;
                return View(obj);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await Operation.GetByIdAsync(id);
            var result = mapper.Map<OperationVM>(data);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var data = await Operation.GetByIdAsync(id);
            var result = mapper.Map<OperationVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OperationVM obj)
        {
            if (ModelState.IsValid == true)
            {
                var data = mapper.Map<Operation>(obj);
                await Operation.UpdateAsync(data);
                TempData["SuccessMessage"] = "تم تحديث العملية الجراحية بنجاح!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Operation.GetByIdAsync(id);
            var result = mapper.Map<OperationVM> (data);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(OperationVM Obj )
        {
            try
            {
                var data = mapper.Map<Operation>(Obj);
                await Operation.DeleteAsync(data);
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
