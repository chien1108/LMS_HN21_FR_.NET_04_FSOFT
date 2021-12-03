using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.CategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.CategoryService
{
    public class InstructorCategoryService : IInstructorCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InstructorCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoryVm>> GetAllCategory()
        {
            var categories = await _unitOfWork.Categories.GetAll();
            var model = _mapper.Map<List<CategoryVm>>(categories);
            return model;
        }
    }
}
