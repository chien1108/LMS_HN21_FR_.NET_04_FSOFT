using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminServices.AdminSettingService
{
    public interface IAdminSettingService
    {
        Task<ServiceResponse<AdminSetting>> Create(AdminSetting newAdminSetting);

        Task<ServiceResponse<AdminSetting>> Delete(AdminSetting adminSettingVM);
        Task<ServiceResponse<AdminSetting>> Update(AdminSetting updateAdminSetting);
        Task<bool> IsExisted(Expression<Func<AdminSetting, bool>> expression = null);
        Task<IList<AdminSetting>> FindAll(Expression<Func<AdminSetting,
                                bool>> expression = null,
                                Func<IQueryable<AdminSetting>,
                               IOrderedQueryable<AdminSetting>> orderBy = null,
                                List<string> includes = null);
        Task<AdminSetting> Find(Expression<Func<AdminSetting, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}