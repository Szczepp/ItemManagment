using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ItemManagement.DomainModels;
using ItemManagement.DomainModels.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItemManagement.DataLayer
{
    public class ItemManagementDbContext: IdentityDbContext<ApplicationUser>
    {
        public ItemManagementDbContext(): base("DefaultItemManagementConnection")
        {
             
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCollection> ItemCollections { get; set; }
    }
}
