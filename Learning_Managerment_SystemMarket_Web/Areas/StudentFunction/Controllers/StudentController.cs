using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Mvc;
using Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Models;
using System;
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


        public StudentController(
            IStudentHomePageService studentHomePageService
            , ISavedCourseService savedCourseService
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IStudentExploreService studentExploreService)

        {
            _studentHomePageService = studentHomePageService;
            _mapper = mapper;
            _studentExploreService = studentExploreService;

            _unitOfWork = unitOfWork;

            _savedCourseService = savedCourseService;

        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> CourseDetails(int id)
        {
            var isExists = await _unitOfWork.Courses.FindByCondition(q => q.Id == id);
            if (isExists == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CourseDetailVM>(isExists);
            return View(model);
        }



        public IActionResult Explore(string searchString, int? page)
        {
            var courses = Task.Run(() => _studentExploreService.SearchCourse(searchString)).Result;
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

            StudentExploreVM studentExploreVM = new StudentExploreVM
            {
                Courses = courses.Skip(start).Take(pageSize).ToList(),
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