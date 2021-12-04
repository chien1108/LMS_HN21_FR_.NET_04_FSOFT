using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_Services.StudentServices.SubcriptionService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    [Area("StudentFunction")]
    public class FilterPageController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavedCourseService _savedCourseService;
        private readonly ISubcriptionService _subcriptionService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public FilterPageController(
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
        /// TamLV10 Filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult Filter()
        {
            return View();
        }
    }
}
