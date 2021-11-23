using AutoMapper;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;

        public StudentController(IStudentHomePageService studentHomePageService, IMapper mapper)
        {
            this._studentHomePageService = studentHomePageService;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult SavedCourses()
        {
            return View();
        }

        public IActionResult Filter()
        {
            return View(); 
        }

<<<<<<< HEAD
        //public async Task<IActionResult> GetCourseByCategory(int id)
        //{
        //    var course = _studentHomePageService.FindCourse(c => c.CategoryId == id);
        //}
=======
        public async Task<IActionResult> GetCourseByCategory(int id)
        {
<<<<<<< HEAD:Learning_Managerment_SystemMarket_Web/Areas/StudentFunction/Controllers/StudentController.cs
            var courses = await _studentHomePageService.FindAllCourse(c => c.CategoryId == id);
            return View(courses);
=======
            var course = await _studentHomePageService.FindCourse(c => c.CategoryId == id);
            return View();
>>>>>>> d4e12d7ce85e5857cf821193bff8886ebf62944b:Learning_Managerment_SystemMarket_Web/Controllers/StudentController.cs
        }
>>>>>>> 5811c0e0c9c07931fd281ba6e0dcbed146462f7e
    }
}
