using ItemManagement.DomainModels.Identity;
using ItemManagement.RepositoryContracts;
using ItemManagement.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.ServiceLayer
{
    public class ApplicationUserService : IApplicationUserService
    {
        ApplicationUserRepository _appUserRepo;
        public ApplicationUserService()
        {
            _appUserRepo = new ApplicationUserRepository();

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

        public void SignInApplicationUser(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }
        public void UpdateApplicationUser(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}
