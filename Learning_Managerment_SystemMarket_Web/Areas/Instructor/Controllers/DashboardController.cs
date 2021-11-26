using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo;
using Microsoft.AspNetCore.Mvc;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
using System;
using Learning_Managerment_SystemMarket_Web.Areas.Instructor.Models;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.DashboardViewModels;

namespace Learning_Managerment_SystemMarket_Web.Areas.Instructor.Controllers
{
    [Area("Instructor")]
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
            var courses = await _unitOfWork.Courses.GetAll();

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
                TotalSales =  await ToTalSales(),
                TotalEnroll = await TotalEnroll(),
                TotalCourses = await TotalCourses(),
                TotalStudents = await TotalStudents(),
                TotalViews = await TotalView(),
                SubmitCourses = coursesInPage,
                LastSellCourses = lastSellCourses.ToList()
            };

            return View(model);

        }


        public async Task<decimal>  ToTalSales()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructorId);

            decimal totalSale = 0;
            foreach(var course in courses)
            {
                totalSale += await GetSaleByCourses(course);
            }

            return totalSale;
        }


        //get total sale theo khoa hoc trong ngay hom nay theo instructor
        public async Task<decimal> ToTalSalesToday()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructorId);

          
            decimal totalSale = 0;
            foreach (var course in courses)
            {
                totalSale += await GetSaleByCoursesToday(course);
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

            foreach(var order in orderByCourses)
            {
                totalSale += order.Price;
            }

            return totalSale;
        }

        public async Task<decimal> GetSaleByCoursesToday(Course course)
        {
            var courseId = course.Id;
            var orders = await _unitOfWork.Orders.GetAll( o => o.CreatedDate == System.DateTime.Now);

            var orderByCourses = orders.Where(o => o.CourseId == courseId).ToList();
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
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructorId && c.Orders.Count() >0);

            return courses.Count();
        }

        // tong so khoa hoc co student enroll trong ngay hom nay cua instructor
        public async Task<int> TotalEnrollToday()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructorId && c.Orders.Count() > 0);

            var coursesToday = courses.Where(c => c.Orders.Where(o => o.CreatedDate == System.DateTime.Now).Any());
            return coursesToday.Count();
        }


        // tong khoa hoc cua instructor
        public async Task<int> TotalCourses()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll( 
              c => c.InstructorId == instructorId);
            return courses.Count();
        }


        // tinh tong student tham gia cac khoa hoc cua instructor
        public async Task<int> TotalStudents()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructorId);

             var student = new List<Student>();

            foreach(var course in courses)
            {
                student.AddRange(await GetStudentByCourses(course));
            }

            return student.Distinct().Count();
        }

        // lay danh sach student cua khoa hoc
        public async Task<List<Student>> GetStudentByCourses(Course course)
        {
            var courseId = course.Id;
            var students = await _unitOfWork.Students.GetAll();
            
            var studentByCourses = students.Where(sc => sc.Orders == course.Orders);

            return studentByCourses.ToList();

        }

        // lay danh sach student cua khoa hoc
        public async Task<List<Student>> GetStudentByCoursesToday(Course course)
        {
            var courseId = course.Id;
            var students = await _unitOfWork.Students.GetAll();

            var studentByCourses = students.Where(sc => sc.Orders == course.Orders);

            var studentByCoursesToday = studentByCourses.Where(sc => sc.Orders.Where(o => o.CreatedDate == System.DateTime.Now).Any());

            return studentByCourses.ToList();

        }

        public async Task<int> TotalView()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor.Id;
            var courses = await _unitOfWork.Courses.GetAll(
              c => c.InstructorId == instructorId);

            int totalView = 0;
            foreach (var course in courses)
            {
                totalView +=  course.Views;
            }

            return totalView;
        }

    }
    
}
