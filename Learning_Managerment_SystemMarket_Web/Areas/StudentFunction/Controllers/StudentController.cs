using AutoMapper;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
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
        private readonly IStudentExploreService _studentExploreService;

        public StudentController(IStudentHomePageService studentHomePageService, IMapper mapper, IStudentExploreService studentExploreService)
        {
            _studentHomePageService = studentHomePageService;
            _mapper = mapper;
            _studentExploreService = studentExploreService;
        }

        public  IActionResult Index()
        {
            return View();
        }


       
        public IActionResult Explore()
        {
            var courses = Task.Run(() => _studentExploreService.GetAllCourseIsActive()).Result;
            StudentExploreVM studentExploreVM = new StudentExploreVM
            {
                Courses =  courses
            };
            return View(studentExploreVM);
        }
        public async Task<IActionResult> SavedCourses()

        {
            //var courses = await _studentHomePageService.GetCourseByStudentId(0);
            var courses = await _studentHomePageService.GetCourseByStudent();
        
            return View(courses);
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
