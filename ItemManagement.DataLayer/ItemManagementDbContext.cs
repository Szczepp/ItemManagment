using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ItemManagement.DomainModels;

namespace ItemManagement.DataLayer
{
    public class ItemManagementDbContext: DbContext 
    {
        public ItemManagementDbContext(): base("ConnectionStringAzure")
        {
             
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCollection> ItemCollections { get; set; }
    }
}
