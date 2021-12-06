using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Core.Repositories.InstructorRepo;
using LMS.Web.Areas.IdentityMVC.Models.SettingViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.InstructorFunction.Controllers
{
    //[Authorize]
    [Area("InstructorFunction")]
    [Route("/Instructor/Setting/[Action]")]
    public class SettingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<SettingController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepo;

        public SettingController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILogger<SettingController> logger,
        IUnitOfWork unitOfWork, IMapper mapper,
        IInstructorRepository instructorRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _instructorRepo = instructorRepo;
        }


        // GET: /intructor/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            TempData["StatusMessage"] =
                message == ManageMessageId.UpdateAccount ? "You just update account success"
                : message == ManageMessageId.ChangePasswordSuccess ? "you have just successfully updated your password."
                : message == ManageMessageId.Error ? "Some thing wrong."
                : message == ManageMessageId.ErrorPassword ? "Unable to update password."
                : message == ManageMessageId.ChangeNotification ? "You just changed notification."
                : "";

            var user = await _userManager.GetUserAsync(User);
            var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == user.IdUser);

            var model = new EditExtraProfileModel()
            {
                InstructorId = instructor.Id,
                InstructorName = instructor.InstructorName,
                HeadLine = instructor.HeadLine,
                Description = instructor.Description,
                Image = instructor.Image,
                Website = instructor.Website,
                Facebook = instructor.Facebook,
                LinkedIn = instructor.LinkedIn,
                Youtube = instructor.Youtube,
                EmailNotification = Convert.ToBoolean(instructor.EmailNotification),
                PushNotification = Convert.ToBoolean(instructor.PushNotification),
                Email = user.Email,
            };
         
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditExtraProfileModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == user.IdUser);

            instructor.InstructorName = model.InstructorName;
            instructor.HeadLine = model.HeadLine;
            instructor.Description = model.Description;
            instructor.Website = model.Website;
            instructor.Facebook = model.Facebook;
            instructor.LinkedIn = model.LinkedIn;
            instructor.Youtube = model.Youtube;

            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    instructor.Image = dataStream.ToArray();
                }
            }

            _unitOfWork.Instructors.Update(instructor);
            await _unitOfWork.Save();

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.UpdateAccount });
        }

        public enum ManageMessageId
        {
            UpdateAccount,
            ErrorPassword,
            ChangePasswordSuccess,
            Error,
            ChangeNotification
        }

    
        // POST: /Instructor/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(EditExtraProfileModel model)
        {

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User changed their password successfully.");
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ErrorPassword });
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeNotification(EditExtraProfileModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var instructor = await _unitOfWork.Instructors.FindByCondition(x => x.Id == user.IdUser);

            instructor.EmailNotification = Convert.ToInt32(model.EmailNotification);
            instructor.PushNotification = Convert.ToInt32(model.PushNotification);
            
            _unitOfWork.Instructors.Update(instructor);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangeNotification });
        }
    }
}