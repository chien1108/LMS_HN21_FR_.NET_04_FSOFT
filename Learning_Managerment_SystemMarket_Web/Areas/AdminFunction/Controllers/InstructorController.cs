using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.AdminFunction.InstructorService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Controllers
{
    [Area("AdminFunction")]
    public class InstructorController : Controller
    {
        private readonly ILogger<InstructorController> _logger;
        private readonly IInstructorService _instructorService;
        private readonly ICourseServices _courseService;
        private readonly IMapper _mapper;

        public InstructorController(ILogger<InstructorController> logger, IInstructorService instructorService, IMapper mapper, ICourseServices courseService)
        {
            _logger = logger;
            _instructorService = instructorService;
            _mapper = mapper;
            _courseService = courseService;
        }

        // GET: InstructorController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ManagerInstructor()
        {
            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult ViewInfo(int id, int idIns)
        {
            ViewBag.IdCourse = id;
            ViewBag.IdInstructor = idIns;
            return View();
        }

        // GET: StudentController/Details/5
        public ActionResult InstructorInfo(int id)
        {
            ViewBag.IdInstructor = id;
            return View();
        }

        // GET: InstructorController/Details/5
        public async Task<ActionResult> ChangeBlockInstructor(int id)
        {
            var instructor = await _instructorService.Find(x => x.Id == id);
            if (instructor == null)
            {
                return RedirectToAction(nameof(ManagerInstructor));
            }

            if (instructor.Status == StatusIns.Active)
            {
                instructor.Status = StatusIns.Deactive;
            }
            else
            {
                instructor.Status = StatusIns.Active;
            }

            var respone = await _instructorService.Update(instructor);
            if (!respone.Success)
            {
                ModelState.AddModelError("", respone.Message);
                return RedirectToAction(nameof(ManagerInstructor));
            }
            return RedirectToAction(nameof(ManagerInstructor));
        }
        public async Task<ActionResult> ChangeBlockCourse(int id, int idIns)
        {
            var course = await _courseService.Find(x => x.Id == id);
            if (course == null)
            {
                return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
            }
            if (course.Status == StatusCourse.Active)
            {
                course.Status = StatusCourse.Deactive;
            }
            else
            {
                course.Status = StatusCourse.Active;
            }
            var respone = await _courseService.Update(course);
            if (!respone.Success)
            {
                ModelState.AddModelError("", respone.Message);
                return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
            }
            return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
        }
        // GET: InstructorController/Details/5
        public async Task<ActionResult> ChangeBestSeller(int id, int idIns)
        {
            var course = await _courseService.Find(x => x.Id == id);
            if (course == null)
            {
                return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
            }

            if (course.IsBestseller)
            {
                course.IsBestseller = false;
            }
            else
            {
                course.IsBestseller = true;
            }

            var respone = await _courseService.Update(course);
            if (!respone.Success)
            {
                ModelState.AddModelError("", respone.Message);
                return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
            }
            return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
        }

        // GET: InstructorController/Details/5
        public async Task<ActionResult> ChangeFeatured(int id, int idIns)
        {
            var course = await _courseService.Find(x => x.Id == id);
            if (course == null)
            {
                return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
            }

            if (course.IsFeatured)
            {
                course.IsFeatured = false;
            }
            else
            {
                course.IsFeatured = true;
            }

            var respone = await _courseService.Update(course);
            if (!respone.Success)
            {
                ModelState.AddModelError("", respone.Message);
                return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
            }
            return RedirectToAction(nameof(InstructorInfo), new { id = idIns });
        }
    }
}
