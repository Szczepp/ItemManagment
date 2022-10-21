using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using ItemManagement.DomainModels.Identity;
using ItemManagement.DataLayer;
using ItemManagement.DataLayer.Identity;
using ItemManagement.RepositoryLayer;

[assembly: OwinStartup(typeof(ItemManagement.Startup))]

namespace ItemManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            var appUserRepo = new ApplicationUserRepository();
            appUserRepo.CreateInitialRolesAndUsers();
        }

       
    }
}
