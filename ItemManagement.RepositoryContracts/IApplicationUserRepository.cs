using ItemManagement.DomainModels;
using ItemManagement.DomainModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.RepositoryContracts
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetApplicationUsers();
        List<ApplicationUser> SearchApplicationUser(string Name);
        ApplicationUser GetApplicationUserById(long id);
        void UpdateApplicationUser(ApplicationUser applicationUser); 
        void DeleteApplicationUser(long id);
    }
}
