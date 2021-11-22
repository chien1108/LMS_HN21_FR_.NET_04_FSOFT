using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminServices.AdminSettingService
{
    public class AdminSettingService : IAdminSettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminSettingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AdminSetting>> Create(AdminSetting newAdminSetting)
        {
            var adminSettingFromDb = await Find(x => x.Id == newAdminSetting.Id);
            if (adminSettingFromDb == null)
            {
                await _unitOfWork.AdminSettings.Create(newAdminSetting);
                return new ServiceResponse<AdminSetting> { Success = true, Message = "Add AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<AdminSetting> { Success = false, Message = "AdminSetting is Exist" };
            }
        }

        public async Task<ServiceResponse<AdminSetting>> Delete(AdminSetting adminSettingVM)
        {
            var adminSettingFromDB = await Find(x => x.Id == adminSettingVM.Id);
            if (adminSettingFromDB != null)
            {
                _unitOfWork.AdminSettings.Delete(adminSettingVM);
                return new ServiceResponse<AdminSetting> { Success = true, Message = "Delete AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<AdminSetting> { Success = false, Message = "Not Found AdminSetting" };
            }
        }

        public async Task<AdminSetting> Find(Expression<Func<AdminSetting,bool>> expression = null,
                                                List<string> includes = null) 
            => await _unitOfWork.AdminSettings.FindByCondition(expression, includes);

        public async Task<IList<AdminSetting>> FindAll(Expression<Func<AdminSetting, bool>> expression = null,
                                                        Func<IQueryable<AdminSetting>, IOrderedQueryable<AdminSetting>> orderBy = null,
                                                        List<string> includes = null) 
            => await _unitOfWork.AdminSettings.GetAll(expression, orderBy, includes);

        public async Task<bool> IsExisted(Expression<Func<AdminSetting, bool>> expression = null)
        => await _unitOfWork.AdminSettings.IsExists(expression);

        public async Task<bool> SaveChange()
                    => await _unitOfWork.Save();
        

        public async Task<ServiceResponse<AdminSetting>> Update(AdminSetting updateAdminSetting)
        {
            var adminSettingFromDB = await Find(x => x.Id == updateAdminSetting.Id);
            if (adminSettingFromDB != null)
            {
                _unitOfWork.AdminSettings.Update(updateAdminSetting);
                return new ServiceResponse<AdminSetting> { Success = true, Message = "Update AdminSetting Success" };
            }
            else
            {
                return new ServiceResponse<AdminSetting> { Success = false, Message = "Not Found AdminSetting" };
            }
        }
    }
}