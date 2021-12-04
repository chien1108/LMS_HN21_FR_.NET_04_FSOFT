using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.SubCategoryService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    public class CourseController : Controller
    {
        private static List<CreateCourseContentVm> createCourseContentVms = new List<CreateCourseContentVm>();
        private static List<CreateLectureVm> createLectureVms = new List<CreateLectureVm>();

        private readonly IInstructorSubCategoryService _subCategoryService;
        private readonly ICourseServices _courseServices;
        private static byte[] _picture;
        private readonly UserManager<User> _userManager;

        public CourseController(IInstructorSubCategoryService subCategoryService, ICourseServices courseServices, UserManager<User> userManager)
        {
            _subCategoryService = subCategoryService;
            _courseServices = courseServices;
            _userManager = userManager;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var instructor = _userManager.GetUserAsync(User).Result;
            var courses = _courseServices.GetAllCourses(instructor.IdUser);
            var model = new DisCountCourseVm
            {
                Courses = courses.Result
            };
            return View(model);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    _picture = p1;
                    return Json(true);
                }
                return Json(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tạo Course mới SonNL4
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> CreateCourse(CreateCourseVm model)
        {
            var user = await _userManager.GetUserAsync(User);
            var instructorId = user.IdUser;
            var responseResult = new ResponseResult
            {
                Code = false,
                Message = "Please add at least one Course Content"
            };
            if (createCourseContentVms.Count() < 1 || createLectureVms.Count() < 1)
            {
                return Json(responseResult);
            }
            if (ModelState.IsValid)
            {
                model.CoverImage = _picture;
                var result = model;
                responseResult = await _courseServices.CreateCourse(model, createCourseContentVms, createLectureVms, instructorId);
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                responseResult.Message = message;
            }  

            return Json(responseResult);
        }

        /// <summary>
        /// Thêm Course Content vào list SonNL4
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateCourseContent(CreateCourseContentVm model)
        {
            var responseResult = new ResponseResult
            {
                Code = false,
                Message = "Please add at least one Course Content"
            };
            if (ModelState.IsValid)
            {
                createCourseContentVms.Add(model);
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                responseResult.Message = message;
            }

            return Json(responseResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDiscount(DisCountCourseVm model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is invalid");
                return RedirectToAction(nameof(Index));
            }

            var result = _courseServices.CreateDiscount(model);

            if (result.Result.Success == true)
            {                
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }            
        }

        [HttpGet]
        public ActionResult CreateLecture(CreateLectureVm model)
        {
            var responseResult = new ResponseResult
            {
                Code = false,
                Message = "Please add at least one Lecture"
            };
            if (ModelState.IsValid)
            {
                createLectureVms.Add(model);
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                responseResult.Message = message;
            }
            return Json(responseResult);
        }

        [HttpGet]
        public ActionResult GetSubCategory(int id)
        {
            var result = _subCategoryService.GetSubCategoryByCategoryId(id);
            return Json(result.Result);
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(int id)
        {
            var result = _courseServices.Delete(id);
            if (result.Result.Success == true)
            {
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }            
        }

        public ActionResult ChangeStatusToDraft(int id)
        {
            var course = _courseServices.ChangeStatusToDraft(id);
            if (course.Result.Success == false)
            {
                TempData["Message"] = course.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = course.Result.Message;
                return RedirectToAction(nameof(Index));
            }            
        }

        public ActionResult ChangeStatusToPending(int id)
        {
            var course = _courseServices.ChangeStatusToPending(id);
            if (course.Result.Success == false)
            {
                TempData["Message"] = course.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = course.Result.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult ChangeStatus(int id)
        {            
            var discountCourse = _courseServices.ChangeStatus(id);
            if (discountCourse.Result.Success == false)
            {                
                TempData["Message"] = discountCourse.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {  
                TempData["Message"] = discountCourse.Result.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiscount(int id)
        {
            var result = _courseServices.DeleteDiscount(id);
            if (result.Result.Success == true)
            {
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }            
        }

        [HttpGet]
        public ActionResult EditDiscount(int id)
        {
            var discount = _courseServices.GetDiscountById(id);

            return View(discount.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDiscount(DisCountCourseVm entity)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Model is invalid");
                return RedirectToAction(nameof(EditDiscount), new { id = entity.Id });
            }

            var result = _courseServices.UpdateDiscount(entity);

            if (result.Result.Success == false)
            {
                ModelState.AddModelError("", result.Result.Message);
                return RedirectToAction(nameof(EditDiscount), new { id = entity.Id });
            }
            else
            {
                TempData["Message"] = result.Result.Message;
                return RedirectToAction(nameof(Index));
            }           
        }
    }
}