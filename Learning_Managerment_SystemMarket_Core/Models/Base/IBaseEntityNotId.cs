using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;

namespace Learning_Managerment_SystemMarket_Core.Models.Base
{
    public interface IBaseEntityNotId
    {
        Status Status { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}
