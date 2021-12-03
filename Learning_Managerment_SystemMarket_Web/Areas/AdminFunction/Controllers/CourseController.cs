using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Controllers
{
    [Area("AdminFunction")]
    public class CourseController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ICourseServices _courseService;
        private readonly IMapper _mapper;
        public CourseController(ILogger<StudentController> logger, ICourseServices courseService, IMapper mapper)
        {
            _logger = logger;
            _courseService = courseService;
            _mapper = mapper;
        }
        // GET: CourseController
        public ActionResult WaitToApprove()
        {
            return View();
        }


        public async Task<ActionResult> ChangeToActive(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return RedirectToAction(nameof(WaitToApprove));
            }

            if (course.Status == StatusCourse.Active)
            {
                course.Status = StatusCourse.Active;
            }
            else
            {
                course.Status = StatusCourse.Active;
            }

            var respone = await _courseService.Update(course);
            if (!respone.Success)
            {
                ModelState.AddModelError("", respone.Message);
                return RedirectToAction(nameof(WaitToApprove));
            }
            return RedirectToAction(nameof(WaitToApprove));
        }
    }
}
