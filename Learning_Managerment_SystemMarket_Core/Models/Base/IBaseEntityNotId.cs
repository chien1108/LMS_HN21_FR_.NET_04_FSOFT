using System;

namespace Learning_Managerment_SystemMarket_Core.Models.Base
{
    public interface IBaseEntityNotId
    {
        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}