using System;
using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_Core.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        private DateTime? _createdDate;

        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.Now; }
            set { _createdDate = value; }
        }

        public DateTime? ModifiedDate { get; set; }
    }
}