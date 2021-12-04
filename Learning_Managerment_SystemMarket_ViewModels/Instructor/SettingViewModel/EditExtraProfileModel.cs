using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LMS.Web.Areas.IdentityMVC.Models.SettingViewModels
{
  public class EditExtraProfileModel
  {
        public string InstructorName { get; set; }
        public string HeadLine { get; set; } = null;
        public string Image { get; set; }
        public string Website { get; set; } = null;
        public string Facebook { get; set; } = null;
        public string LinkedIn { get; set; } = null;
        public string Youtube { get; set; } = null;
        public string Description { get; set; } = null;
        public int EmailNotification { get; set; } = 1;// nhận thông báo
        public int PushNotification { get; set; } = 1;
        public DateTime? EmailVerifiedAt { get; set; }
        public StatusIns Status { get; set; }
        public decimal Balance { get; set; }

        public string Email { get; set; }
 
    }
}