using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.AdminFunction.StudentService;
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
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, IMapper mapper)
        {
            _logger = logger;
            _studentService = studentService;
            _mapper = mapper;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult ManagerStudent()
        {
            return View();
        }


        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> ChangeBlock(int id)
        {
            var student = await _studentService.Find(x => x.Id == id);
            if (student == null)
            {
                return RedirectToAction(nameof(ManagerStudent));
            }

            if (student.Status == StatusStudent.Active)
            {
                student.Status = StatusStudent.Deactive;
            }
            else
            {
                student.Status = StatusStudent.Active;
            }

            var respone = await _studentService.Update(student);
            if (!respone.Success)
            {
                ModelState.AddModelError("", respone.Message);
                return RedirectToAction(nameof(ManagerStudent));
            }
            return RedirectToAction(nameof(ManagerStudent));
        }


        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
