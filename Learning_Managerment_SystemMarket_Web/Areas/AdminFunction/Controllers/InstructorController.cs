using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.AdminFunction.InstructorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Controllers
{
    [Area("AdminFunction")]
    public class InstructorController : Controller
    {
        private readonly ILogger<InstructorController> _logger;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public InstructorController(ILogger<InstructorController> logger, IInstructorService instructorService, IMapper mapper)
        {
            _logger = logger;
            _instructorService = instructorService;
            _mapper = mapper;
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
        public ActionResult InstructorInfo(int id)
        {
            ViewBag.IdInstructor = id;
            return View();
        }

        // GET: InstructorController/Details/5
        public async Task<ActionResult> ChangeBlock(int id)
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
    }
}
