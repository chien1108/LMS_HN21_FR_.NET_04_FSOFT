using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.ClaimService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.UserService;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleClaimViewModels;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.RoleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly IClaimService _claimService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(ILogger<RoleController> logger,
                            IMapper mapper,
                            UserManager<User> userManager,
                            RoleManager<Role> roleManager,
                            IUserService userService,
                            IRoleService roleService,
                            IClaimService claimService)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _roleService = roleService;
            _claimService = claimService;
        }


        public IActionResult ManageRoleClaim(int id)
        {
            ViewBag.IdRole = id;
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
        public async Task<ActionResult> Create(RoleVM newRoleVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManageRoleClaim));
                }

                var response = await _roleService.Create(new Role { Name = newRoleVM.Name });
                if (response.Success == false)
                {
                    ModelState.AddModelError("", response.Message);
                    return RedirectToAction(nameof(ManageRoleClaim));
                }
                var role = await _roleService.Find(x => x.Name.ToLower().Trim() == newRoleVM.Name.ToLower().Trim());

                if (newRoleVM.Claims != null)
                {
                    foreach (var item in newRoleVM.Claims)
                    {
                            var response1 = await _claimService.Create(new Claim() { RoleId = role.Id, ClaimType = item.ClaimType, ClaimValue = item.ClaimType });
                            if (response1.Success == false)
                            {
                                ModelState.AddModelError("", response.Message);
                                return RedirectToAction(nameof(ManageRoleClaim));
                            }
                    }
                }

                return RedirectToAction(nameof(ManageRoleClaim));
            }
            catch
            {
                return RedirectToAction(nameof(ManageRoleClaim));
            }
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction(nameof(ManageRoleClaim), new { id = id });
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RoleVM roleVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManageRoleClaim));
                }
                var role = await _roleService.Find(x => x.Id == roleVM.Id);
                if (role == null)
                {
                    return RedirectToAction(nameof(ManageRoleClaim), new { id = roleVM.Id });
                }
                //category.CategoryName = model.CategoryName;
                //category.Status = model.Status;
                role.Name = roleVM.Name;
                var respone = await _roleService.Update(role);
                if (!respone.Success)
                {
                    ModelState.AddModelError("", respone.Message);
                    return RedirectToAction(nameof(ManageRoleClaim), new { id = roleVM.Id });
                }
                return RedirectToAction(nameof(ManageRoleClaim));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Update not success");
                return RedirectToAction(nameof(ManageRoleClaim));
            }
        }

        // GET: RoleController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManageRoleClaim));
                }
                var role = await _roleService.Find(x => x.Id == id);

                if (role == null)
                {
                    ModelState.AddModelError("", "Record not exist");
                    return RedirectToAction(nameof(ManageRoleClaim));
                }
                var respone = await _roleService.Delete(role);
                var responeClaim = await _claimService.Delete(role.Id);
                if (!respone.Success || !responeClaim.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(ManageRoleClaim));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Delete not success");
                return RedirectToAction(nameof(ManageRoleClaim));
            }
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
