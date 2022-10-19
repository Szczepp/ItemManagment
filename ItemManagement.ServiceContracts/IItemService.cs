using ItemManagement.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.ServiceContracts
{
    public interface IItemService
    {
        List<Item> GetItems();
        List<Item> SearchItem(string Name);
        Item GetItemById(long id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(long id);
    }
}
