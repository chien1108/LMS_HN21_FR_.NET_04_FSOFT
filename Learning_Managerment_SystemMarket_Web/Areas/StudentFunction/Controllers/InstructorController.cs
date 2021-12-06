using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.InstructorService;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_Services.StudentServices.SubcriptionService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    [Area("StudentFunction")]
    public class InstructorController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavedCourseService _savedCourseService;
        private readonly ISubcriptionService _subcriptionService;
        private readonly IStudentInstructorService _studentInstructorService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public InstructorController(
            IStudentHomePageService studentHomePageService
            , ISavedCourseService savedCourseService
            , IUnitOfWork unitOfWork
            , IMapper mapper
            , IStudentExploreService studentExploreService,
            ISubcriptionService subcriptionService,
            IStudentInstructorService studentInstructorService,
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
            _studentInstructorService = studentInstructorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> InstructorDetails(int id)
        {
            var instructor = await _studentInstructorService.GetInstructorById(id);
            return View(instructor);
        }
        /// <summary>
        /// Get instructions by student id VuTV10
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>List instruction</returns>
        public async Task<IActionResult> GetSubcriptionByStudentId(string searchString,int id, int? page)
        {
            var instructions = await _studentInstructorService.SearchInstructorByStudentId(searchString,id);
            var collection = _mapper.Map<ICollection<Learning_Managerment_SystemMarket_Core.Models.Entities.Instructor>, ICollection<CardInstructorVM>>(instructions);

            if (page <= 0 || page == null)
            {
                page = 1;
            }
            int pageSize = 12;
            int start = (int)(page - 1) * pageSize;

            int totalPage = instructions.Count;
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
                Instructors = collection.Skip(start).Take(pageSize).ToList(),
                SearchString = searchString
            };
            return View(studentExploreVM);
        }
     
        /// <summary>
        /// Get all instructor VuTV10
        /// </summary>
        /// <returns>List instructor</returns>
        public async Task<IActionResult> BrowseInstructors()
        {
            var instructors = await _studentInstructorService.GetAllInstructor();
            return View(instructors);
        }
    }
}
