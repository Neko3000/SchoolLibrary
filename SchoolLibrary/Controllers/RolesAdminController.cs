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

using System.Net;

namespace SchoolLibrary.Controllers
{
    public class RolesAdminController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public ApplicationDbContext context { get; private set; }

        public RolesAdminController()
        {
            context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public RolesAdminController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        //Get: /RolesAdmin/
        public async Task<ActionResult> Index()
        {
            return View(RoleManager.Roles);
        }

        //Get: /RolesAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = await RoleManager.FindByIdAsync(id);

            var users = new List<ApplicationUser>();
            foreach(var user in role.Users)
            {
                users.Add(await UserManager.FindByIdAsync(user.UserId));
            }

            RoleDetailsViewModel vm = new RoleDetailsViewModel();
            vm.Users = users;
            vm.Role = role;

            return View(vm);
        }

        //Get: /RolesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: /RolesAdmin/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole(roleViewModel.Name);
                var roleResult = await RoleManager.CreateAsync(role);
                if(!roleResult.Succeeded)
                {
                    ModelState.AddModelError("", roleResult.Errors.First().ToString());
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Get: /RolesAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if(role==null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //Post: /RolesAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Name,Id")] IdentityRole role)
        {
            if(ModelState.IsValid)
            {
                var result = await RoleManager.UpdateAsync(role);
                if(!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().ToString());
                    return View();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Get: /RolesAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role=await RoleManager.FindByIdAsync(id);
            if(role==null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //Get: /RolesAdmin/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            if (ModelState.IsValid)
            {
                if(id==null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                var result = await RoleManager.DeleteAsync(role);
                if(!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First().ToString());
                    return View();
                }
                
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}