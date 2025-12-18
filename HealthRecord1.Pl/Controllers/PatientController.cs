using AutoMapper;
using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthRecord1.PL.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatient Patient;
        private readonly IMapper mapper;

        public PatientController(IPatient P, IMapper mapper)
        {
            this.Patient = P;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string? SearchValue)
        {
            IEnumerable<HealthRecord1.DAL.Entities.Patient> data;

            if (!string.IsNullOrWhiteSpace(SearchValue))
            {
                // البحث بالاسم الأول أو اسم العائلة أو الرقم الوطني أو رقم الهاتف
                data = await Patient.GetAllAsync(p => 
                    p.FirstName.Contains(SearchValue) || 
                    p.LastName.Contains(SearchValue) ||
                    p.NationalId.Contains(SearchValue) ||
                    (p.PhoneNumber != null && p.PhoneNumber.Contains(SearchValue)) ||
                    (p.PhoneNumber2 != null && p.PhoneNumber2.Contains(SearchValue)));
            }
            else
            {
                // جلب جميع المرضى
                data = await Patient.GetAllAsync();
            }

            var result = mapper.Map<IEnumerable<PatientVM>>(data);
            
            // تمرير SearchValue للـ View للحفاظ على قيمة البحث
            ViewBag.SearchValue = SearchValue;
            
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new PatientVM 
            { 
                IsActive = true,
                CreationDate = DateTime.Now,
                DateOfBirth = DateTime.Now.AddYears(-30) // Default age
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PatientVM obj)
        {
            try
            {
                // معالجة الصورة
                if (obj.Image != null && obj.Image.Length > 0)
                {
                    // Step 1: Save Image to wwwroot/PatientImages
                    string ImagePath = Directory.GetCurrentDirectory() + @"/wwwroot/PatientImages/";
                    
                    // Step 2: Ensure the directory exists
                    if (!Directory.Exists(ImagePath))
                    {
                        Directory.CreateDirectory(ImagePath);
                    }
                    
                    // Step 3: Get file name and combine path
                    string ImageName = Path.GetFileName(obj.Image.FileName);
                    string FinalImagePath = Path.Combine(ImagePath, ImageName);
                    
                    // Step 4: Save the file
                    using (var stream = new FileStream(FinalImagePath, FileMode.Create))
                    {
                        obj.Image.CopyTo(stream);
                    }
                    
                    obj.ImageName = ImageName;
                }
                else
                {
                    // استخدام الصورة الافتراضية
                    obj.ImageName = "default-avatar.svg";
                }

                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Patient>(obj);
                    data.CreationDate = DateTime.Now;
                    await Patient.CreateAsync(data);
                    TempData["SuccessMessage"] = "تم إضافة المريض بنجاح!";
                    return RedirectToAction("Index");
                }
                TempData["ErrorMessage"] = "البيانات المدخلة غير صحيحة، يرجى التحقق والمحاولة مرة أخرى.";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء إضافة المريض: " + ex.Message;
                return View(obj);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await Patient.GetByIdAsync(id);
            var result = mapper.Map<PatientVM>(data);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await Patient.GetByIdAsync(id);
            var result = mapper.Map<PatientVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PatientVM obj)
        {
            if (ModelState.IsValid == true)
            {
                // معالجة الصورة الجديدة إذا تم رفعها
                if (obj.Image != null && obj.Image.Length > 0)
                {
                    // حذف الصورة القديمة إن وجدت
                    if (!string.IsNullOrEmpty(obj.ImageName))
                    {
                        string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PatientImages", obj.ImageName);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // حفظ الصورة الجديدة
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PatientImages");
                    string imageName = Path.GetFileName(obj.Image.FileName);
                    string finalImagePath = Path.Combine(imagePath, imageName);

                    using (var stream = new FileStream(finalImagePath, FileMode.Create))
                    {
                        obj.Image.CopyTo(stream);
                    }

                    obj.ImageName = imageName;
                }
                // إذا لم يتم رفع صورة جديدة، نحتفظ بالصورة القديمة
                // obj.ImageName سيحتوي على القيمة القديمة من الـ hidden field

                var data = mapper.Map<Patient>(obj);
                await Patient.UpdateAsync(data);
                TempData["SuccessMessage"] = "تم تحديث بيانات المريض بنجاح!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await Patient.GetByIdAsync(id);
            var result = mapper.Map<PatientVM>(data);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PatientVM Obj)
        {
            try
            {
                var data = mapper.Map<Patient>(Obj);
                await Patient.DeleteAsync(data);
                TempData["SuccessMessage"] = "تم حذف المريض بنجاح!";
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "حدث خطأ أثناء حذف المريض: " + ex.Message;
                return View(Obj);
            }
        }
    }
}
