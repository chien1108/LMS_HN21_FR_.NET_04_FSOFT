using Learning_Managerment_SystemMarket_Services.InstructorServices.SubCategoryService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseContentViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
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
        private readonly ISubCategoryService _subCategoryService;

        public CourseController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
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

        // POST: CourseController/Create
        [HttpPost]
        public ActionResult Create([Bind("Title,SubTitile,Description,IsFree,CategoryId,SubcategoryId,LanguageId")] CreateCourseTest model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult CreateCourse(CreateCourseVm model)
        {
            var result = model;
            return Json(result);
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
