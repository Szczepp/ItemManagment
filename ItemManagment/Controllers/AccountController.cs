using ItemManagement.DataLayer;
using ItemManagement.DataLayer.Identity;
using ItemManagement.DomainModels.Identity;
using ItemManagement.RepositoryContracts;
using ItemManagement.ServiceContracts;
using ItemManagement.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ItemManagement.Controllers
{
    public class AccountController : Controller
    {
        ItemManagementDbContext _db;
        ApplicationUserManager _userManager;
        ApplicationUserStore _userStore;
        public AccountController()
        {
            _db = new ItemManagementDbContext();
            _userStore = new ApplicationUserStore(_db);
            _userManager = new ApplicationUserManager(_userStore);
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var passwordHash = Crypto.HashPassword(model.Password);

                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    PasswordHash = passwordHash,
                };
                IdentityResult result = _userManager.Create(user);
                if (result.Succeeded)
                {
                    //_userManager.AddToRole(user.Id, "Customer");

                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("My error", "Invalid data");
                return View();
            }
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
        if (ModelState.IsValid)
        {
            var user = _userManager.Find(model.UserName, model.Password);
            if (user != null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                   // _userManager.AddToRole(user.Id, "User"); not working, dont know why

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Error", "Invalid username or password");
            return View();
        }
        ModelState.AddModelError("Error", "Invalid data");
        return View();
    }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}