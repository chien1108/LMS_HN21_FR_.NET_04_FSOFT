using Learning_Managerment_SystemMarket_Core.Modules.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LMS.Web.Areas.IdentityMVC.Models.SettingViewModels
{
    public class EditExtraProfileModel
    {
        public int InstructorId { get; set; }

        [Required]
        [Display(Name = "Current password")]
        public string InstructorName { get; set; }

        public string HeadLine { get; set; } = null;
        public byte[] Image { get; set; }
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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}