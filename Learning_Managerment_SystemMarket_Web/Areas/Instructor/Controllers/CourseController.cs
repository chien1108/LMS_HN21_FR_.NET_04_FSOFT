using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.SubCategoryService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.LectureViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.ResponseResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.Instructor.Controllers
{
    [Area("Instructor")]
    public class CourseController : Controller
    {
        static List<CreateCourseContentVm> createCourseContentVms = new List<CreateCourseContentVm>();
        static List<CreateLectureVm> createLectureVms = new List<CreateLectureVm>();

        private readonly ISubCategoryService _subCategoryService;
        private readonly ICourseServices _courseServices;

        public CourseController(ISubCategoryService subCategoryService, ICourseServices courseServices)
        {
            _subCategoryService = subCategoryService;
            _courseServices = courseServices;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Tạo Course mới SonNL4
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> CreateCourse(CreateCourseVm model)
        {
            var responseResult = new ResponseResult {
                Code = false,
                Message = "Empty value"
            };
            if (createCourseContentVms.Count() < 1)
            {
                return Json(responseResult);
            }
            if (ModelState.IsValid)
            {
                var result = model;
                responseResult = await _courseServices.CreateCourse(model, createCourseContentVms, createLectureVms);
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
            if (ModelState.IsValid)
            {

                createCourseContentVms.Add(model);
            }
            
            return Json(model.Title);
        }

        /// <summary>
        /// Thêm Course Content vào list SonNL4
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateLecture(CreateLectureVm model)
        {
            createLectureVms.Add(model);
            var result = model;
            return Json(result.Title);
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
