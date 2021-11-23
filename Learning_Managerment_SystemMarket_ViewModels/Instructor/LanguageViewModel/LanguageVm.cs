using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_ViewModels.Instructor.LanguageViewModel
{
    public class LanguageVm
    {
        public int Id { get; set; }

        public string LanguageName { get; set; }

        public Status Status { get; set; }
    }
}
