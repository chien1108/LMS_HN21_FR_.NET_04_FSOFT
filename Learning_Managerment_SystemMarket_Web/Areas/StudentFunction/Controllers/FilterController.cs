using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using Learning_Managerment_SystemMarket_Services.StudentServices.SavedCourseService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentExploreService;
using Learning_Managerment_SystemMarket_Services.StudentServices.StudentHomePageService;
using Learning_Managerment_SystemMarket_ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.StudentFunction.Controllers
{
    [Area("StudentFunction")]
    public class FilterController : Controller
    {
       
        public IActionResult FilterPage(ConditionItem condition)
        {
            return View(condition);

        }

        public IActionResult FilterNewest(ConditionItem condition)
        {
            return View(condition);
        }

        public IActionResult FilterLowestPrice(ConditionItem condition)
        {
            return View(condition);
        }

        public IActionResult FilterHighestPrice(ConditionItem condition)
        {
            return View(condition);
        }
    }
}