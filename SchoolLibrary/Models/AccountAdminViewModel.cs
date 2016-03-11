using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;


namespace SchoolLibrary.Models
{
    //User Admin 
    public class UsersAdminCreateViewModel
    {
        public IEnumerable<ApplicationUser> Users;
    }
    //create
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name ="RoleName")]
        public string Name { get; set; }
    }

    //details
    public class RoleDetailsViewModel
    {
        public IdentityRole Role { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}