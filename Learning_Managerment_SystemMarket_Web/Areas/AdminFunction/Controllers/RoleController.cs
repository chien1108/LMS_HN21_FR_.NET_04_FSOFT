using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.UserService;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserClaimViewModles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Controllers
{
    [Area("AdminFunction")]
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(ILogger<RoleController> logger, 
                            IMapper mapper, 
                            UserManager<User> userManager, 
                            RoleManager<Role> roleManager,
                            IUserService userService,
                            IRoleService roleService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimVM userVM)
        {
            var user = await _userService.Find(x => x.Id == userVM.UserId);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userVM.UserId} cannot be found";
                return View("Not Found");
            }
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(userVM);
            }
            result = await _userManager.AddClaimsAsync(user, userVM.Cliams.Where(c => c.IsSelected).Select(c => new System.Security.Claims.Claim(c.ClaimType, c.ClaimType)));
            if(!result.Succeeded)
            {
                ModelState.AddModelError("","Cannot add select claims to user");
                return View(userVM);
            }
            return View();
        }
        // GET: RoleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role newRole)
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

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction(nameof(ManageUserClaims), new { id = id });
        }

        // POST: RoleController/Edit/5
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

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
