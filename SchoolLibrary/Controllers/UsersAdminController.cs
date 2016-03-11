using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolLibrary.Models;

using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;

using System.Net;

namespace SchoolLibrary.Controllers
{
    public class UsersAdminController : Controller
    {
        //
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get;private set; }
        public ApplicationDbContext context { get; private set; }
        //
        public UsersAdminController()
        {
            context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        //Get: /Users/
        public async Task<ActionResult> Index()
        {
            var indexVM = new UsersAdminIndexViewModel();
            indexVM.Users = await UserManager.Users.ToListAsync();

            return View(indexVM);
        }
        //Get: /Users/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = await UserManager.FindByIdAsync(id);
            //ViewBag.RolesForUser =await UserManager.GetRolesAsync(id);

            var detailsVM = new UsersAdminDetailsViewModel();
            detailsVM.Id = user.Id;
            detailsVM.UserName = user.UserName;
            detailsVM.Email = user.Email;
            detailsVM.PhoneNumber = user.PhoneNumber;
            detailsVM.CurrentRoles = await UserManager.GetRolesAsync(user.Id);
            detailsVM.Logins = user.Logins;

            return View(detailsVM);
        }
        //Get: /User/Create
        public async Task<ActionResult> Create()
        {
            //get the list of the roles
            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Id", "Name");

            var createVM = new UsersAdminCreateViewModel();
            createVM.Roles = RoleManager.Roles;
            return View(createVM);
        }

        //Post: /Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel userViewModel,string RoleId)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser();
                //add UserName to the RegisterViewModel
                user.UserName = userViewModel.UserName;
                user.Email = userViewModel.Email;

                var adminResult = await UserManager.CreateAsync(user, userViewModel.Password);
                if(adminResult.Succeeded)
                {
                    //contains RoleId 
                    if(!string.IsNullOrEmpty(RoleId))
                    {
                        //find role admin
                        var role = await RoleManager.FindByIdAsync(RoleId);
                        var result = await UserManager.AddToRoleAsync(user.Id, role.Name);

                        //failed
                        if(!result.Succeeded)
                        {
                            ModelState.AddModelError("", result.Errors.First().ToString());
                            ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(),"Id", "Name");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", adminResult.Errors.First().ToString());
                        ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                    }
                }
                //succeed to add a new user
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                //failed to add
                return View();
            }

        }

        //Get: /Users/Edit/1
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            //ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");

            var user = await UserManager.FindByIdAsync(id);
            if(user==null)
            {
                return HttpNotFound();
            }

            var editVM = new UsersAdminEditViewModel();
            editVM.Id = user.Id;
            editVM.UserName = user.UserName;
            editVM.Email = user.Email;
            editVM.PhoneNumber = user.PhoneNumber;
            editVM.CurrentRoles = await UserManager.GetRolesAsync(user.Id);
            editVM.Roles = RoleManager.Roles;

            return View(editVM);
        }

        //Get: /User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserName,Id,Email")] ApplicationUser formuser, string id, string RoleId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);              
            }
            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
            var user = await UserManager.FindByIdAsync(id);
            user.UserName = formuser.UserName;
            user.Email = formuser.Email;

            if (ModelState.IsValid)
            {
                //update the user details
                await UserManager.UpdateAsync(user);

                //if user has existing Role then remove the user from the role
                //this also accounts for the case when the Admin selected Empty from the drop-down and
                //this means that all roles for the user must be removed
                var rolesForUser = await UserManager.GetRolesAsync(id);
                if (rolesForUser.Count() > 0)
                {
                    foreach (var item in rolesForUser)
                    {
                        var result = await UserManager.RemoveFromRoleAsync(id, item);
                    }
                }

                if (!string.IsNullOrEmpty(RoleId))
                {
                    //find role
                    var role = await RoleManager.FindByIdAsync(RoleId);
                    //add user to new role
                    var result = await UserManager.AddToRoleAsync(id, role.Name);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RoleId = new SelectList(RoleManager.Roles, "Id", "Name");
                return View();
            }
            
        }      
    }
}