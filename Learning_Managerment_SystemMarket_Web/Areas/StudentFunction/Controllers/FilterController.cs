using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    [Area("StudentFunction")]
    public class FilterController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavedCourseService _savedCourseService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public FilterController(
            IStudentHomePageService studentHomePageService
            , ISavedCourseService savedCourseService
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IStudentExploreService studentExploreService,
            UserManager<User> userManager,
            SignInManager<User> signInManager)

        {
            _studentHomePageService = studentHomePageService;
            _mapper = mapper;
            _studentExploreService = studentExploreService;
            _unitOfWork = unitOfWork;
            _savedCourseService = savedCourseService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FilterPage(ConditionItem condition)
        {
            if (condition.CategoryId!=null
                &&condition.LanguageId!=null
                &&condition.IsPrice==false
                &&condition.CourseDuration!=null)
            {
                var coursesNewest = await _studentHomePageService.FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.CategoryId == condition.CategoryId
                    && x.LanguageId == condition.LanguageId
                    && x.IsFree == condition.IsPrice
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return View(coursesNewest);
               
            }
            var courses = await _studentHomePageService.FindAllCourse(
                   expression: x => x.Status == StatusCourse.Active
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                                    .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
            return View(courses);

        }


        public async Task<IActionResult> FilterNewest(ConditionItem condition)
        {
            if (condition.CategoryId != null
                && condition.LanguageId != null
                && condition.IsPrice == false
                && condition.CourseDuration != null)
            {
                var courses = await _studentHomePageService.FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    && x.CategoryId == condition.CategoryId
                    && x.LanguageId == condition.LanguageId
                    && x.IsFree == condition.IsPrice
                   , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return View(courses);
            }
            var coursesNewest = await _studentHomePageService.FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    , orderBy: x => x.OrderByDescending(a => a.ModifiedDate)
                                     .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
            return View(coursesNewest);
        }

        public async Task<IActionResult> FilterLowestPrice(ConditionItem condition)
        {
            if (condition.CategoryId != null
                && condition.LanguageId != null
                && condition.IsPrice == false
                && condition.CourseDuration != null)
            {
                var courses = await _studentHomePageService.FindAllCourse(
                   expression: x => x.Status == StatusCourse.Active
                   && x.CategoryId == condition.CategoryId
                    && x.LanguageId == condition.LanguageId
                    && x.IsFree == condition.IsPrice
                   , orderBy: x => x.OrderBy(a => a.Price)
                .ThenByDescending(a => a.ModifiedDate)
                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
                return View(courses);
            }

            var coursesLowestPrice = await _studentHomePageService.FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    , orderBy: x => x.OrderBy(a => a.Price)
                 .ThenByDescending(a => a.ModifiedDate)
                    .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
            return View(coursesLowestPrice);
        }

        public async Task<IActionResult> FilterHighestPrice(ConditionItem condition)
        {
            if (condition.CategoryId != null
                && condition.LanguageId != null
                && condition.IsPrice == false
                && condition.CourseDuration != null)
            {
                var courses = await _studentHomePageService.FindAllCourse(
                   expression: x => x.Status == StatusCourse.Active
                    && x.CategoryId == condition.CategoryId
                     && x.LanguageId == condition.LanguageId
                     && x.IsFree == condition.IsPrice
                   , orderBy: x => x.OrderByDescending(a => a.Price)
                                   .ThenByDescending(a => a.ModifiedDate)
                                   .ThenByDescending(a => a.CreatedDate)
                   , includes: new List<string>() { "Instructor", "SubCategory", "Category" });

                return View(courses);
               
            }

            var coursesHighestPrice = await _studentHomePageService.FindAllCourse(
                    expression: x => x.Status == StatusCourse.Active
                    , orderBy: x => x.OrderByDescending(a => a.Price)
                                    .ThenByDescending(a => a.ModifiedDate)
                                    .ThenByDescending(a => a.CreatedDate)
                    , includes: new List<string>() { "Instructor", "SubCategory", "Category" });
            return View(coursesHighestPrice);
        }
    }
}