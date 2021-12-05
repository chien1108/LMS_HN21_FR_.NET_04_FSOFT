using AutoMapper;
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

        public ActionResult ListReject()
        {
            return View();
        }

        public async Task<ActionResult> ChangeToActive(int id)
        {
            var respone = await _courseService.ChangeToActive(id);
            if (!respone)
            {
                ModelState.AddModelError("", "Error");
                return RedirectToAction(nameof(WaitToApprove));
            }
            return RedirectToAction(nameof(WaitToApprove));
        }
    }
}
