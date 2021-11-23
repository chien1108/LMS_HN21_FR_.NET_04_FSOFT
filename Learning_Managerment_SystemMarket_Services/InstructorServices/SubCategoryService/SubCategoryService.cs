using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_ViewModels.Instructor.SubCategoryViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.InstructorServices.SubCategoryService
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SubCategoryVm>> GetSubCategoryByCategoryId(int id)
        {
            var subCategories = await _unitOfWork.SubCategories.GetAll(x => x.CategoryId == id);
            var model = _mapper.Map<List<SubCategoryVm>>(subCategories);
            return model;
        }
    }
}
