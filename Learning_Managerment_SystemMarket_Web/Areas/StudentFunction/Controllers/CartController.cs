using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.StudentServices.CartService;
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
    public class CartController : Controller
    {
        private readonly IStudentHomePageService _studentHomePageService;
        private readonly IMapper _mapper;
        private readonly IStudentExploreService _studentExploreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISavedCourseService _savedCourseService;
        private readonly ISubcriptionService _subcriptionService;
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public CartController(
            IStudentHomePageService studentHomePageService,
            ISavedCourseService savedCourseService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStudentExploreService studentExploreService,
            ISubcriptionService subcriptionService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ICartService cartService)

        {
            _studentHomePageService = studentHomePageService;
            _mapper = mapper;
            _studentExploreService = studentExploreService;
            _unitOfWork = unitOfWork;
            _savedCourseService = savedCourseService;
            _subcriptionService = subcriptionService;
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
        }

        /// <summary>
        /// Get all cart by student id VuTV10
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns>List cart of student</returns>
        public async Task<IActionResult> GetCartByStudentId(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return View(new CartVM());
            }
            if (id == null)
                id = user.IdUser;

            var cartItems = await _cartService.FindAll(
                expression: c => c.StudentId == id,
                includes: new List<string> { "Course" });

            var cart = new CartVM
            {
                Carts = cartItems,
                Total = cartItems.Sum(c => c.Course.Price)
            };
            return View(cart);
        }

        /// <summary>
        /// Add course to cart VuTV10
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <param name="studentId">Student Id</param>
        /// <returns>Success</returns>
        public async Task<IActionResult> AddCourseToCart(int courseId, int studentId)
        {
            try
            {
                var existingCart = await _cartService.Find(expression: c => c.CourseId == courseId && c.StudentId == studentId);
                if (existingCart != null)
                {
                    return RedirectToAction(nameof(GetCartByStudentId));
                }
                var cart = new Cart
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    CreatedDate = DateTime.Now
                };
                var respon = await _cartService.Create(cart);
                if (!respon.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(GetCartByStudentId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete course from cart VuTV10
        /// </summary>
        /// <param name="courseId">Course id</param>
        /// <param name="studentId">Student id</param>
        /// <returns>Success</returns>
        public async Task<IActionResult> DeleteCourseFromCart(int courseId, int studentId)
        {
            try
            {
                var cart = await _cartService.Find(expression: c => c.CourseId == courseId && c.StudentId == studentId);
                var respon = await _cartService.Delete(cart);
                if (!respon.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(GetCartByStudentId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Checkout cart VuTV10
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>Success or false</returns>
        public async Task<IActionResult> Payment(int studentId)
        {
            try
            {
                var respon = await _cartService.Payment(studentId);
                if (!respon.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(GetCartByStudentId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}