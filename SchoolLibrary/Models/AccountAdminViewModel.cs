using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;


namespace SchoolLibrary.Models
{
    //User Admin
    //Index
    public class UsersAdminIndexViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
    }

    //Create-post
    public class UsersAdminCreateViewModel
    {
        [Required]
        [Display(Name = "账户名")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "联系电话")]
        public string PhoneNumber { get; set; }

        [Display(Name = "账户权限列表")]
        public IQueryable<IdentityRole> Roles { get; set; }
    }

    //Details
    public class UsersAdminDetailsViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name ="账户名")]
        public string UserName { get; set; }

        [Display(Name ="电子邮件")]
        public string Email { get; set; }

        [Display(Name = "联系电话")]
        public string PhoneNumber { get; set; }

        [Display(Name ="当前账户权限")]
        public IList<string> CurrentRoles { get; set; }

        public ICollection<IdentityUserLogin> Logins { get; set; }
    }

    //Edit-get/post
    public class UsersAdminEditViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "账户名")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "电子邮件")]
        public string Email { get; set; }

        [Display(Name = "联系电话")]
        public string PhoneNumber { get; set; }

        [Display(Name="当前账户权限")]
        public IList<string> CurrentRoles { get; set; }

        [Display(Name = "账户权限列表")]
        public IQueryable<IdentityRole> Roles { get; set; }
    }

    public class RoleViewModel
    {
        public string Name { get; set; }
    }


    //Edit-post
    public class RoleDetailsViewModel
    {
        public IdentityRole Role { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}