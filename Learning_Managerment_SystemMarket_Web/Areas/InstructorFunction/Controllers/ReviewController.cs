using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseRateService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    public class ReviewController : Controller
    {
        private readonly IInstructorCourseRateService _instructorCourseRateService;
        private readonly ICourseServices _courseServices;
        private readonly UserManager<User> _userManager;

        public ReviewController(IInstructorCourseRateService instructorCourseRateService, ICourseServices courseServices, UserManager<User> userManager)
        {
            _instructorCourseRateService = instructorCourseRateService;
            _courseServices = courseServices;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.GetUserAsync(User);
            //var instructorId = user.IdUser;
            var listCourse = await _courseServices.GetAllCourses(3);

            var courseRates = new ArrayList();

            foreach (var item in listCourse)
            {
                var courseName = item.Title;
                var courseRate = await _instructorCourseRateService.GetCourseRates(expression: c => c.CourseId == item.Id, includes: new List<string> { "Student", "Course" });
                courseRates.Add(courseRate);
            }
            ViewBag.CourseRates = courseRates;
            return View();
        }
    }
}
