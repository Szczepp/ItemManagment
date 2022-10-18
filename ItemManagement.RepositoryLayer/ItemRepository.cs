using ItemManagement.DataLayer;
using ItemManagement.DomainModels;
using ItemManagement.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.RepositoryLayer
{
    public class ItemRepository : IItemRepository
    {
        ItemManagementDbContext _db;
        public ItemRepository()
        {
            _db = new ItemManagementDbContext();
        }
        public void CreateItem(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
        }

        public void DeleteItem(long id)
        {
            var item = this.GetItemById(id);
            _db.Items.Remove(item);
            _db.SaveChanges();
        }

        public Item GetItemById(long id)
        {
            return _db.Items.Find(id);
        }

        public List<Item> GetItems()
        {
            return _db.Items.ToList();
        }

        public List<Item> SearchItem(string Name)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            var existingItem = this.GetItemById(item.Id);

            _db.Entry(existingItem).CurrentValues.SetValues(item);
            _db.SaveChanges();

        }
    }
}
