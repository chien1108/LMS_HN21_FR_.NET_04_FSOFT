using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly ISavedCourseService _savedCourseService;

        public StudentController(
            IStudentHomePageService studentHomePageService
            , ISavedCourseService savedCourseService
            , IMapper mapper
            , IStudentExploreService studentExploreService)
        {
            _studentHomePageService = studentHomePageService;
            _mapper = mapper;
            _studentExploreService = studentExploreService;
            _savedCourseService = savedCourseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Explore()
        {
            var courses = Task.Run(() => _studentExploreService.GetAllCourseIsActive()).Result;
            StudentExploreVM studentExploreVM = new StudentExploreVM
            {
                Courses = courses
            };
            return View(studentExploreVM);
        }

        /// <summary>
        /// TamLV10 SavedCourses
        /// </summary>
        /// <returns>List Savedcourses include courses</returns>
        public async Task<IActionResult> SavedCourses()

        {
            var courses = await _savedCourseService.GetSavedCoursesByStudentId(1);
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
            var model = _mapper.Map<ICollection<CourseDetailVM>>(courses);
            return View(model);
        }

        /// <summary>
        /// Delete SavedCourse
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <returns>SavedCoure</returns>
        public async Task<IActionResult> Delete(int studentId, int courseId)
        {
            var savedCourse = await _savedCourseService.FindSavedCourse(studentId, courseId);
            if (savedCourse == null)
            {
                return NotFound();
            }
            _savedCourseService.Delete(savedCourse);
            await _studentHomePageService.SaveChange();
            return RedirectToAction(nameof(SavedCourses));
        }

        /// <summary>
        /// Delete SavedCourse
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="savedCourse"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int studentId, int courseId,SavedCourse savedCourse)
        {
            try
            {
                savedCourse = await _savedCourseService.FindSavedCourse(studentId, courseId);
                if (savedCourse == null)
                {
                    return NotFound();
                }
                _savedCourseService.Delete(savedCourse);
                await _studentHomePageService.SaveChange();

                return RedirectToAction(nameof(SavedCourses));
            }
            catch
            {
                return View(savedCourse);
            }
        }
    }
}