using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;

namespace Learning_Managerment_SystemMarket_Core.Models.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}