using Learning_Managerment_SystemMarket_Services.InstructorServices.SendEmailService;
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
    public class FeedbackController : Controller
    {
        private readonly IEmailSender _emailSender;

        public FeedbackController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string from, string body)
        {
            var result = _emailSender.SendEmail(from, body);
            if(result == "Success")
            {
                TempData["Message"] = "Send Email Success";
                return View();
            }
            else
            {
                TempData["Message"] = "Send Email Fail because" + result;
                return View();
            }
        }
    }
}
