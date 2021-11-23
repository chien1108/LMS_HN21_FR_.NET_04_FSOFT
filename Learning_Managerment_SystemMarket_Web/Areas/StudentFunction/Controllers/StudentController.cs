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
        /// <summary>
        /// Get all course by category id VuTV10
        /// </summary>
        /// <param name="id">CategoryId</param>
        /// <returns>List course</returns>
        public async Task<IActionResult> GetCourseByCategory(int id)
        {
            var courses = await _studentHomePageService.FindAllCourse(c => c.CategoryId == id);
            return View(courses);
        }
    }
}
