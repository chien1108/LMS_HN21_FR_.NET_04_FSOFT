using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_Services.StudentServices.SubcriptionService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseViewModel;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    [Area("StudentFunction")]
    public class StudentController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavedCourseService _savedCourseService;
        private readonly ISubcriptionService _subcriptionService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public StudentController(
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

        /// <summary>
        /// Index Page - SonHH8
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null )
            {
                if (user.WhoIs == 2)
                {
                    return RedirectToAction("ManagerCategory", "Category", new { area = "AdminFunction" });
                }
                else if (user.WhoIs == 1)
                {
                    return RedirectToAction("Index","Dashboard", new { area = "InstructorFunction" });
                }
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Course Details by SonHH8</param>
        /// <returns></returns>
        public async Task<IActionResult> CourseDetails(int id)
        {
            var isExists = await _unitOfWork.Courses.FindByCondition(q => q.Id == id, new List<string>() { "Instructor" });
            if (isExists == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CourseVm>(isExists);
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Student");
        }
        public async Task<IActionResult> StudentDetails(int id)
        {
            var user = await _unitOfWork.Students.FindByCondition( q => q.Id == id);
            ViewBag.IdUser = id;
            return View();
        }

        public IActionResult Explore(string searchString, int? page)
        {
            var courses = Task.Run(() => _studentExploreService.SearchCourse(searchString)).Result;
            var collection = _mapper.Map<ICollection<Course>, ICollection<CardCourseVM>>(courses);

            if (page <= 0 || page == null)
            {
                page = 1;
            }
            int pageSize = 12;
            int start = (int)(page - 1) * pageSize;

            int totalPage = courses.Count;
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);

            var ExplorePagingModel = new ExplorePagingModel
            {
                CurrentPage = page,
                NumSize = numSize,
                SearchString = searchString
            };
            ViewBag.ExplorePagingModel = ExplorePagingModel;
            ViewBag.PageSize = pageSize;
            StudentExploreVM studentExploreVM = new StudentExploreVM
            {
                Courses = collection.Skip(start).Take(pageSize).ToList(),
                SearchString = searchString
            };
            return View(studentExploreVM);
        }

        public async Task<IActionResult> SavedCourses()

        {
            var courses = await _savedCourseService.GetSavedCoursesByStudentId(1);
            if (courses == null)
            {
                return NotFound();
            }
            return View(courses);
        }

        public async Task<IActionResult> SavedToCourse(SavedCoursesVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var savedCourse = _mapper.Map<SavedCourse>(model);
                savedCourse.StudentId = 1;
                savedCourse.CreatedDate = DateTime.Now;

                var isSuccess = await _savedCourseService.CreateSavedCourse(savedCourse);
                if (!isSuccess.Success)
                {
                    ModelState.AddModelError("", isSuccess.Message);
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Subcribe(SubScriptionVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var subScription = _mapper.Map<SubScription>(model);
                
                subScription.CreatedDate = DateTime.Now;

                var isSuccess = await _subcriptionService.CreateSubcription(subScription);
                if (!isSuccess.Success)
                {
                    ModelState.AddModelError("", isSuccess.Message);
                    return Redirect(model.ReturnUrl);
                }
                return Redirect(model.ReturnUrl);
            }
            catch
            {
                return View(model);
            }
        } 
        public async Task<IActionResult> UnSubcribe(SubScriptionVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var subScription = _mapper.Map<SubScription>(model);
                
                

                var isSuccess = await _subcriptionService.DeleteSubcription(subScription);
                if (!isSuccess.Success)
                {
                    ModelState.AddModelError("", isSuccess.Message);
                    return Redirect(model.ReturnUrl);
                }
                return Redirect(model.ReturnUrl);
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Filter(int? page)
        {
            int pageSize = 12;
            var courses = await _studentHomePageService.GetFeatureCourse(pageSize);
            var collection = _mapper.Map<ICollection<Course>, ICollection<CardCourseVM>>(courses);

            if (page <= 0 || page == null)
            {
                page = 1;
            }

            int start = (int)(page - 1) * pageSize;

            int totalPage = courses.Count;
            float totalNumsize = (totalPage / (float)pageSize);
            int numSize = (int)Math.Ceiling(totalNumsize);

            var ExplorePagingModel = new ExplorePagingModel
            {
                CurrentPage = page,
                NumSize = numSize,
            };
            ViewBag.ExplorePagingModel = ExplorePagingModel;

            StudentExploreVM studentExploreVM = new StudentExploreVM
            {
                Courses = collection.Skip(start).Take(pageSize).ToList(),
            };
            return View(studentExploreVM);
        }

        /// <summary>
        /// Get all course by category id VuTV10
        /// </summary>
        /// <param name="id">CategoryId</param>
        /// <returns>List course</returns>
        public async Task<IActionResult> GetCourseByCategory(int id)
        {
            var courses = await _studentHomePageService.FindAllCourse(c => c.CategoryId == id);
            var model = _mapper.Map<ICollection<CardCourseVM>>(courses);
            return View(model);
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