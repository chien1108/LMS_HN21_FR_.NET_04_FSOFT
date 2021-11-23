using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.CategoryServices;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Controllers.AdminController
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, IMapper mapper)
        {
            _logger = logger;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManagerCategory(int id)
        {
            ViewBag.IdCategory = id;
            return View();
        }

        public IActionResult Edit(int id)
        {
            return RedirectToAction(nameof(ManagerCategory),new {id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategortDetailsVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var category = await _categoryService.Find(x=>x.Id == model.Id);
                if (category == null)
                {
                    return RedirectToAction(nameof(ManagerCategory),new {id = model.Id });
                }
                category.CategoryName = model.CategoryName;
                category.Status = model.Status;
                var respone = await _categoryService.Update(category);
                if (!respone.Success)
                {
                    ModelState.AddModelError("",respone.Message);
                    return RedirectToAction(nameof(ManagerCategory), new { id = model.Id });
                }
                return RedirectToAction(nameof(ManagerCategory));
            }
            catch (Exception)
            {
                ModelState.AddModelError("","Update not success");
                return RedirectToAction(nameof(ManagerCategory));
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategortDetailsVm model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var category = _mapper.Map<Category>(model);
                var response = await _categoryService.Create(category);
                if (response.Success == false)
                {
                    ModelState.AddModelError("", response.Message);
                    return RedirectToAction(nameof(ManagerCategory));
                }
                return RedirectToAction(nameof(ManagerCategory));
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ManagerCategory));
                }
                var category = await _categoryService.Find(x => x.Id == id);
                if (category == null)
                {
                    ModelState.AddModelError("","Record not exist");
                    return RedirectToAction(nameof(ManagerCategory));
                }
                var respone = await _categoryService.Delete(category);
                if (!respone.Success)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(ManagerCategory));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Delete not success");
                return RedirectToAction(nameof(ManagerCategory));
            }
        }
    }
}