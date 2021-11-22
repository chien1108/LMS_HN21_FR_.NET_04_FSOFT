using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Learning_Managerment_SystemMarket_Services.AdminFunction.CategoryServices;
using Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult ManagerCategory()
        {
            return View();
        }

        [HttpPost]
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
                    ModelState.AddModelError("",response.Message);
                    return View(model);
                }
                return RedirectToAction(nameof(ManagerCategory));
            }
            catch (Exception)
            {

                return View(model);
            }

        }
    }
}
