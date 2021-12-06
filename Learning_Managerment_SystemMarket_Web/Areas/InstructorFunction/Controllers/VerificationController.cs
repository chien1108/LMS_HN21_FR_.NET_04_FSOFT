using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    [Authorize]
    public class VerificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
