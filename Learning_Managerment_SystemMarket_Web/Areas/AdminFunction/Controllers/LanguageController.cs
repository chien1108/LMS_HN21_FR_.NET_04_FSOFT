using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.LanguageService;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.LanguageViewModels;
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
    public class LanguageController : Controller
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;
        public LanguageController(ILogger<LanguageController> logger, ILanguageService languageService, IMapper mapper)
        {
            _logger = logger;
            _languageService = languageService;
            _mapper = mapper;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManagerLanguage(int id)
        {
            ViewBag.IdLanguage = id;
            return View();
        }

        // GET: LanguageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
      
        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LanguageVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var language = _mapper.Map<Language>(model);
                var response = await _languageService.Create(language);
                if (response.Success == false)
                {
                    ModelState.AddModelError("", response.Message);
                    return RedirectToAction(nameof(ManagerLanguage));
                }
                return RedirectToAction(nameof(ManagerLanguage));
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction(nameof(ManagerLanguage), new { id = id });
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LanguageVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var language = await _languageService.Find(x => x.Id == model.Id);
                if (language == null)
                {
                    return RedirectToAction(nameof(ManagerLanguage), new { id = model.Id });
                }
                language.LanguageName = model.LanguageName;
                language.Status = model.Status;
                var respone = await _languageService.Update(language);
                if (!respone.Success)
                {
                    ModelState.AddModelError("", respone.Message);
                    return RedirectToAction(nameof(ManagerLanguage), new { id = model.Id });
                }
                return RedirectToAction(nameof(ManagerLanguage));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Update not success");
                return RedirectToAction(nameof(ManagerLanguage));
            }
        }

        // GET: LanguageController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManagerLanguage));
                }
                var language = await _languageService.Find(x => x.Id == id);
                if (language == null)
                {
                    ModelState.AddModelError("", "Record not exist");
                    return RedirectToAction(nameof(ManagerLanguage));
                }
                var respone = await _languageService.Delete(language);
                if (!respone.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(ManagerLanguage));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Delete not success");
                return RedirectToAction(nameof(ManagerLanguage));
            }
        }

       
    }
}
