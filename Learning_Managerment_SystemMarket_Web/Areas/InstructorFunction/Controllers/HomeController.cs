using Microsoft.AspNetCore.Mvc;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}