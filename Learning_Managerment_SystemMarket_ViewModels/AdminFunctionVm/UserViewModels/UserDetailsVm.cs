using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Learning_Managerment_SystemMarket_ViewModels.AdminFunctionVm.UserViewModels
{
    public class UserDetailsVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public MultiSelectList SelectedRoles { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public List<int> RolesId { get; set; }
    }

    public class UserEditsVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        public MultiSelectList SelectedRoles { get; set; }

        [Required]
        [Display(Name = "Roles")]
        public List<int> RolesId { get; set; }
    }
}