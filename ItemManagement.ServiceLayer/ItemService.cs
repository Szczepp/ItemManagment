using ItemManagement.DomainModels;
using ItemManagement.RepositoryLayer;
using ItemManagement.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.ServiceLayer
{
    public class ItemService : IItemService
    {
        ItemRepository _itemRepo;

        public ItemService()
        {
            _itemRepo = new ItemRepository();
        }
        public void CreateItem(Item item)
        {
            _itemRepo.CreateItem(item);
        }

        public void DeleteItem(long id)
        {
            _itemRepo.DeleteItem(id);
        }

        public Item GetItemById(long id)
        {
            return _itemRepo.GetItemById(id);
        }

        public List<Item> GetItems()
        {
            return _itemRepo.GetItems();
        }

        public List<Item> SearchItem(string Name)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            _itemRepo.UpdateItem(item);
        }
    }
}
