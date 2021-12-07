using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseRateService;
using Learning_Managerment_SystemMarket_Services.InstructorServices.CourseService;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CourseRateViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    [Area("InstructorFunction")]
    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IInstructorCourseRateService _instructorCourseRateService;
        private readonly ICourseServices _courseServices;
        private readonly UserManager<User> _userManager;

        public ReviewController(IInstructorCourseRateService instructorCourseRateService, ICourseServices courseServices, UserManager<User> userManager)
        {
            _instructorCourseRateService = instructorCourseRateService;
            _courseServices = courseServices;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var instructorId = user.IdUser;
            int avarageRate = 0;

            int count = 0;
            int vote1 = 0;
            int vote2 = 0;
            int vote3 = 0;
            int vote4 = 0;
            int vote5 = 0;
            var listCourse = await _courseServices.GetAllCourses(instructorId);

            var courseRates = new ArrayList();
            var courseRate = new List<CourseRateVm>();
            foreach (var item in listCourse)
            {
                courseRate = (List<CourseRateVm>)await _instructorCourseRateService.GetCourseRates(expression: c => c.CourseId == item.Id, includes: new List<string> { "Student", "Course" });

                foreach (var rate in courseRate)
                {
                    rate.PrettyDate = GetPrettyDate(rate.CreatedDate);
                    //math
                    avarageRate += rate.Star;

                    switch (rate.Star)
                    {
                        case 1:
                            vote1++;
                            break;
                        case 2:
                            vote2++;
                            break;
                        case 3:
                            vote3++;
                            break;
                        case 4:
                            vote4++;
                            break;
                        case 5:
                            vote5++;
                            break;
                    }
                    count++;
                }
                courseRates.Add(courseRate);
            }
            if (count > 0)
            {
                ViewData["Vote1"] = Math.Round(((double)vote1 / count) * 100, 0);
                ViewData["Vote2"] = Math.Round(((double)vote2 / count) * 100, 0);
                ViewData["Vote3"] = Math.Round(((double)vote3 / count) * 100, 0);
                ViewData["Vote4"] = Math.Round(((double)vote4 / count) * 100, 0);
                ViewData["Vote5"] = Math.Round(((double)vote5 / count) * 100, 0);
            }
            else
            {
                ViewData["Vote1"] = 0;
                ViewData["Vote2"] = 0;
                ViewData["Vote3"] = 0;
                ViewData["Vote4"] = 0;
                ViewData["Vote5"] = 0;
            }


            ViewData["AvarageRate"] = (double)avarageRate / count;

            ViewBag.CourseRates = courseRates;
            return View();
        }

        private static string GetPrettyDate(DateTime d)
        {
            // 1.
            // Get time span elapsed since the date.
            TimeSpan s = DateTime.Now.Subtract(d);

            // 2.
            // Get total number of days elapsed.
            int dayDiff = (int)s.TotalDays;

            // 3.
            // Get total number of seconds elapsed.
            int secDiff = (int)s.TotalSeconds;

            // 4.
            // Don't allow out of range values.
            if (dayDiff < 0 || dayDiff >= 31)
            {
                return string.Format("{0} months ago",
                        Math.Floor((double)dayDiff / 30));
            }

            if (dayDiff < 0 || dayDiff >= 365)
            {
                return string.Format("{0} year ago",
                        Math.Floor((double)dayDiff / 365));
            }

            // 5.
            // Handle same-day times.
            if (dayDiff == 0)
            {
                // A.
                // Less than one minute ago.
                if (secDiff < 60)
                {
                    return "just now";
                }
                // B.
                // Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                // C.
                // Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }
                // D.
                // Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                // E.
                // Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            // 6.
            // Handle previous days.
            if (dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                    dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",
                    Math.Ceiling((double)dayDiff / 7));
            }
            return null;
        }
    }
}