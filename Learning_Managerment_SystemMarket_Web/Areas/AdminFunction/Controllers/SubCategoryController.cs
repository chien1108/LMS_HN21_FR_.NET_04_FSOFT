using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.SubCategoryService;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.SubCategoryViewModels;
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
    public class SubCategoryController : Controller
    {
        private readonly ILogger<SubCategoryController> _logger;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;


        public SubCategoryController(ILogger<SubCategoryController> logger, ISubCategoryService subCategoryService, IMapper mapper)
        {
            _logger = logger;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }

        // GET: SubCategoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SubCategoryController
        public ActionResult ManagerSubCategory(int id)
        {
            ViewBag.IdSubCategory = id;
            return View();
        }

        // GET: SubCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubCategoryDetailsVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var subCategory = _mapper.Map<SubCategory>(model);
                subCategory.CategoryId = model.CategoryId;
                subCategory.CreatedDate = DateTime.Now;
                var response = await _subCategoryService.Create(subCategory);
                if (response.Success == false)
                {
                    ModelState.AddModelError("", response.Message);
                    return RedirectToAction(nameof(ManagerSubCategory));
                }
                return RedirectToAction(nameof(ManagerSubCategory));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: SubCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction(nameof(ManagerSubCategory), new { id = id });
        }

        // POST: SubCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubCategoryDetailsVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var subCategory = await _subCategoryService.Find(x => x.Id == model.Id);
                if (subCategory == null)
                {
                    return RedirectToAction(nameof(ManagerSubCategory), new { id = model.Id });
                }
                subCategory.SubCategoryName = model.SubCategoryName;
                subCategory.CategoryId = model.CategoryId;
                subCategory.Status = model.Status;

                var respone = await _subCategoryService.Update(subCategory);
                if (!respone.Success)
                {
                    ModelState.AddModelError("", respone.Message);
                    return RedirectToAction(nameof(ManagerSubCategory), new { id = model.Id });
                }
                return RedirectToAction(nameof(ManagerSubCategory));
            }
            catch
            {
                ModelState.AddModelError("", "Update not success");
                return RedirectToAction(nameof(ManagerSubCategory));
            }
        }

        // GET: SubCategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManagerSubCategory));
                }
                var category = await _subCategoryService.Find(x => x.Id == id);
                if (category == null)
                {
                    ModelState.AddModelError("", "Record not exist");
                    return RedirectToAction(nameof(ManagerSubCategory));
                }
                var respone = await _subCategoryService.Delete(category);
                if (!respone.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(ManagerSubCategory));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Delete not success");
                return RedirectToAction(nameof(ManagerSubCategory));
            }
        }
    }
}
