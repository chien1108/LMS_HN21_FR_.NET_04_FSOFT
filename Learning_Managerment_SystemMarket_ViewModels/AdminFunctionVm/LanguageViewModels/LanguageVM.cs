using Learning_Managerment_SystemMarket_Core.Models.Base;
using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.LanguageViewModels
{
    public class LanguageVM 
    {
        public int Id { get; set; }
        [Required]
        public string LanguageName { get; set; }
        public Status Status { get; set; }
    }
}
