using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.RoleService;
using Learning_Managerment_SystemMarket_Services.AdminFunction.UserService;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.AdminFunction.Controllers
{
    [Area("AdminFunction")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ManagerUser(int id)
        {
            ViewBag.IdUser = id;
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDetailsVm model)
        {
            try
            {
                var allRoles = await _roleService.FindAll();
                var roleItems = new MultiSelectList(allRoles, "Id", "Name");

                model.SelectedRoles = roleItems;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var isUserExist = await _userService.IsExisted(model.UserName);
                if (isUserExist)
                {
                    ModelState.AddModelError("", "User is Existed");
                    return RedirectToAction(nameof(ManagerUser), new { id = model.Id });
                }

                var user = _mapper.Map<User>(model);

                var response = await _userService.Create(user, model.Password);
                if (response.Success == false)
                {
                    ModelState.AddModelError("", response.Message);
                    return RedirectToAction(nameof(ManagerUser));
                }

                var roles = new List<string>();
                foreach (var roleId in model.RolesId)
                {
                    var role = await _roleService.Find(x => x.Id == roleId);
                    roles.Add(role.Name);
                }

                var addRoles = await _userService.AddToRoles(user, roles);
                if (!addRoles.Success)
                {
                    ModelState.AddModelError("", addRoles.Message);
                    return RedirectToAction(nameof(ManagerUser), new { id = model.Id });
                }

                return RedirectToAction(nameof(ManagerUser));
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        // GET: UserController/Edit/5
        public IActionResult Edit(int id)
        {
            return RedirectToAction(nameof(ManagerUser), new { id = id });
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditsVm model)
        {
            try
            {
                var allRoles = await _roleService.FindAll();
                var roleItems = new MultiSelectList(allRoles, "Id", "Name");

                model.SelectedRoles = roleItems;

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userService.Find(x => x.Id == model.Id);
                if (user == null)
                {
                    return RedirectToAction(nameof(ManagerUser), new { id = model.Id });
                }

                var userRoles = await _userService.GetUserRoles(user);
                var removeRoles = await _userService.RemoveFromRoles(user, userRoles);
                if (!removeRoles.Success)
                {
                    ModelState.AddModelError("", removeRoles.Message);
                    return RedirectToAction(nameof(ManagerUser), new { id = model.Id });
                }

                var roles = new List<string>();
                foreach (var roleId in model.RolesId)
                {
                    var role = await _roleService.Find(x => x.Id == roleId);
                    roles.Add(role.Name);
                }

                var addRoles = await _userService.AddToRoles(user, roles);
                if (!addRoles.Success)
                {
                    ModelState.AddModelError("", addRoles.Message);
                    return RedirectToAction(nameof(ManagerUser), new { id = model.Id });
                }

                user.UserName = model.UserName;
                var respone = await _userService.Update(user);
                if (!respone.Success)
                {
                    ModelState.AddModelError("", respone.Message);
                    return RedirectToAction(nameof(ManagerUser), new { id = model.Id });
                }
                return RedirectToAction(nameof(ManagerUser));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Update not success");
                return RedirectToAction(nameof(ManagerUser));
            }
        }

        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManagerUser));
                }
                var user = await _userService.Find(x => x.Id == id);
                if (user == null)
                {
                    ModelState.AddModelError("", "Record not exist");
                    return RedirectToAction(nameof(ManagerUser));
                }
                var response = await _userService.Delete(user);
                if (!response.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(ManagerUser));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Delete not success");
                return RedirectToAction(nameof(ManagerUser));
            }
        }
    }
}