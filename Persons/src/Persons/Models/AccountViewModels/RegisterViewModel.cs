using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persons.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Permisos")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }
        public string Role { get; set; }
        private UsersRoles userRoles;

        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();
            userRoles = new UsersRoles();
           
        }

        public void getRoles(RoleManager<IdentityRole> roleManager)
        {
            Roles = userRoles.getRoles(roleManager);

        }

        internal void getRoles(object context)
        {
            throw new NotImplementedException();
        }
    }
}
