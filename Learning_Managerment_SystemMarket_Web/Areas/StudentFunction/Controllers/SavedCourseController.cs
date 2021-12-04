using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_Services.StudentServices.SubcriptionService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    [Area("StudentFunction")]
    public class SavedCourseController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavedCourseService _savedCourseService;
        private readonly ISubcriptionService _subcriptionService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SavedCourseController(
            IStudentHomePageService studentHomePageService
            , ISavedCourseService savedCourseService
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IStudentExploreService studentExploreService,
            ISubcriptionService subcriptionService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)

        {
            _studentHomePageService = studentHomePageService;
            _mapper = mapper;
            _studentExploreService = studentExploreService;
            _unitOfWork = unitOfWork;
            _savedCourseService = savedCourseService;
            _subcriptionService = subcriptionService;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult SavedCourses()
        {
            return View();
        }
        /// <summary>
        /// TamLV10 Save to courses
        /// </summary>
        /// <param name="model">SavedCoursesVM</param>
        /// <param name="studentId">StdentID</param>
        /// <returns></returns>
        public async Task<IActionResult> SavedToCourse(SavedCoursesVM model, int? studentId)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return View(model);
                }
                if (studentId == null)
                    studentId = user.IdUser;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var savedCourse = _mapper.Map<SavedCourse>(model);
                savedCourse.StudentId = (int)studentId;
                savedCourse.CreatedDate = DateTime.Now;

                var savedCourseExisting = await _savedCourseService.FindSavedCourse(model.StudentId, model.CourseId);

                var isSuccess = await _savedCourseService.CreateSavedCourse(savedCourse);
                if (!isSuccess.Success)
                {
                    ModelState.AddModelError("", isSuccess.Message);
                    return RedirectToAction("SavedCourses", "SaveCourse",studentId);
                }
                return RedirectToAction("SavedCourses", "SaveCourse",studentId);
            }
            catch
            {
                return RedirectToAction("CourseDetails", "Student", model.CourseId);
            }
        }


        /// <summary>
        /// TamLV10 RemoveAll savedcorse by studentId
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveAll(int studentId)
        {
            try
            {
                _savedCourseService.DeleteSaveCourses(studentId);
                await _savedCourseService.SaveChanges();
                return RedirectToAction(nameof(SavedCourses));
            }
            catch (Exception)
            {
                return NotFound();
            }
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
            await _savedCourseService.SaveChanges();
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
        public async Task<IActionResult> Delete(int studentId, int courseId, SavedCourse savedCourse)
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
