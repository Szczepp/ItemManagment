using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ItemManagement.Models;

namespace ItemManagement
{
    public class ItemManagementDbContext: DbContext 
    {
        public ItemManagementDbContext(): base("DefaultItemManagementConnection")
        {
             
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemCollection> ItemCollections { get; set; }
    }
}
