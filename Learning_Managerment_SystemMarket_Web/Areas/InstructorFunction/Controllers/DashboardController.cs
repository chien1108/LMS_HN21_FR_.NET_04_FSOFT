using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels;
using Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    [Route("/Instructor/Dashboard/[Action]")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepo;
        private readonly UserManager<User> _userManager;

        public DashboardController(IUnitOfWork unitOfWork, IMapper mapper,
            IInstructorRepository instructorRepo, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _instructorRepo = instructorRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index([FromQuery(Name = "p")] int currentPage, int pageSize)
        {
            var user = await _userManager.GetUserAsync(User);
            var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == user.IdUser);
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            var coursesModel = _mapper.Map<List<SubmitCoursesVM>>(courses.ToList())
                                       .OrderByDescending(c => c.CreatedDate);

            var totalCourses = coursesModel.Count();

            if (pageSize <= 0) pageSize = 5;
            int countPages = (int)Math.Ceiling((double)totalCourses / pageSize);

            if (currentPage > countPages) currentPage = countPages;
            if (currentPage < 1) currentPage = 1;

            var pagingModel = new PagingModel()
            {
                CountPages = countPages,
                CurrentPage = currentPage,
                GenerateUrl = (pageNumber) => Url.Action("Index", new
                {
                    p = pageNumber,
                    pagesize = pageSize
                })
            };

            ViewBag.pagingModel = pagingModel;
            ViewBag.totalCourses = totalCourses;

            ViewBag.postIndex = (currentPage - 1) * pageSize;

            var coursesInPage = coursesModel.Skip((currentPage - 1) * pageSize)
                             .Take(pageSize).ToList();

            var lastSellCourses = _mapper.Map<List<LastSellCoursesVM>>(courses.ToList())
                                       .OrderByDescending(c => c.CreatedDate)
                                       .Take(5);

            var model = new DashboardVM
            {
                TotalSales = await ToTalSales(),
                TotalEnroll = await TotalEnroll(),
                TotalCourses = await TotalCourses(),
                TotalStudents = await TotalStudents(),
                TotalViews = await TotalView(),
                TotalCoursesToday = await TotalCoursesToday(),
                TotalEnrollToday = await TotalEnrollToday(),
                TotalStudentsToday = await TotalStudentsToday(),
                TotalSalesToday = await ToTalSalesToday(),
                TotalSubscriber = await TotalSubscriber(),
                SubmitCourses = coursesInPage,
                LastSellCourses = lastSellCourses.ToList()
            };

            return View(model);
        }
        private Task<Learning_Managerment_SystemMarket_Core.Models.Entities.Instructor> GetInstructorAsync()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var instructor =  _unitOfWork.Instructors.FindByCondition(x => x.Id == user.IdUser);
            return instructor;
        }
      
        public async Task<decimal> ToTalSales()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            decimal totalSale = 0;
            foreach (var course in courses)
            {
                totalSale += await GetSaleByCourses(course);
            }

            return totalSale;
        }

        //get total sale theo khoa hoc
        public async Task<decimal> GetSaleByCourses(Course course)
        {
            var courseId = course.Id;
            var orders = await _unitOfWork.Orders.GetAll();

            var orderByCourses = orders.Where(o => o.CourseId == courseId).ToList();
            decimal totalSale = 0;

            foreach (var order in orderByCourses)
            {
                totalSale += order.Price;
            }

            return totalSale;
        }

        //get total sale theo khoa hoc trong ngay hom nay theo instructor
        public async Task<decimal> ToTalSalesToday()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            decimal totalSale = 0;
            foreach (var course in courses)
            {
                totalSale += await GetSaleByCoursesToday(course);
            }

            return totalSale;
        }

        public async Task<decimal> GetSaleByCoursesToday(Course course)
        {
            var courseId = course.Id;
            var orders = await _unitOfWork.Orders.GetAll();

            var orderByCourses = orders.Where(o => o.CourseId == courseId && o.CreatedDate.Date == System.DateTime.Now.Date).ToList();
            decimal totalSale = 0;

            foreach (var order in orderByCourses)
            {
                totalSale += order.Price;
            }

            return totalSale;
        }

        // tong so khoa hoc co student cua instructor
        public async Task<int> TotalEnroll()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructor.Id && c.Orders.Count() > 0);

            return courses.Count();
        }
                       
        // tong so khoa hoc co student enroll trong ngay hom nay cua instructor
        public async Task<int> TotalEnrollToday()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructor.Id && c.Orders.Count() > 0);

            var coursesToday = courses.Where(c => c.Orders.Where(o => o.CreatedDate.Date == System.DateTime.Now.Date).Any());
            return coursesToday.Count();
        }

        // tong khoa hoc cua instructor
        public async Task<int> TotalCourses()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);
            return courses.Count();
        }

        public async Task<int> TotalCoursesToday()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            var coursesToday = courses.Where(x => x.CreatedDate.Date == System.DateTime.Now.Date);
            return coursesToday.Count();
        }

        // tinh tong student tham gia cac khoa hoc cua instructor
        public async Task<int> TotalStudents()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            int totalStudent = 0;
            foreach (var course in courses)
            {
                totalStudent += await CountStudentByCourses(course);
            }

            return totalStudent;
        }

        // lay danh sach student cua khoa hoc
        public async Task<int> CountStudentByCourses(Course course)
        {
            int count = 0;
            var orders = await _unitOfWork.Orders.GetAll(x => x.CourseId == course.Id);

            count = orders.GroupBy(x => x.StudentId).Select(x => x.First()).Count();

            return count;
        }

        public async Task<int> TotalStudentsToday()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            int totalStudentToday = 0;

            foreach (var course in courses)
            {
                totalStudentToday += await CountStudentByCoursesToday(course);
            }

            return totalStudentToday;
        }

        // lay danh sach student cua khoa hoc
        public async Task<int> CountStudentByCoursesToday(Course course)
        {
            int count = 0;
            var orders = await _unitOfWork.Orders.GetAll(x => x.CourseId == course.Id && x.CreatedDate.Date == System.DateTime.Now.Date);

            count = orders.GroupBy(x => x.StudentId).Select(x => x.First()).Count();

            return count;
        }

        public async Task<int> TotalView()
        {
            var instructor = await GetInstructorAsync();
            var courses = await _unitOfWork.Courses.GetAll(c => c.InstructorId == instructor.Id);

            int totalView = 0;
            foreach (var course in courses)
            {
                totalView += course.Views;
            }

            return totalView;
        }

        public async Task<int> TotalSubscriber()
        {
            var instructor = await GetInstructorAsync();

            var subcriber = await _unitOfWork.Instructors.GetSubcriptionByInstructorId(instructor.Id);            
            return subcriber.Count();
        }
    }
}