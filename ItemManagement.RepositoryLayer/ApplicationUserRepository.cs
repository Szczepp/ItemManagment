using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemManagement.DataLayer.Identity;
using ItemManagement.DataLayer;
using ItemManagement.DomainModels.Identity;
using ItemManagement.RepositoryContracts;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;

namespace ItemManagement.RepositoryLayer
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        ItemManagementDbContext _db;
        ApplicationUserStore _store;
        ApplicationUserManager _UserManager;
        public ApplicationUserRepository()
        {
            _db = new ItemManagementDbContext();
            _store = new ApplicationUserStore(_db);
            _UserManager = new ApplicationUserManager(_store);
        }
        public void CreateInitialRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
         
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
            if (_UserManager.FindByName("Admin") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";
                string userPassword = "Admin123";
                var createdUser = _UserManager.Create(user, userPassword);
                if (createdUser.Succeeded)
                {
                    _UserManager.AddToRole(user.Id, "Admin");
                }
            }
            
        }


        public void DeleteApplicationUser(long id)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetApplicationUserById(long id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetApplicationUsers()
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> SearchApplicationUser(string Name)
        {
            throw new NotImplementedException();
        }

        public void UpdateApplicationUser(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}
