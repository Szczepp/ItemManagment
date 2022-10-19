using ItemManagement.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.ServiceContracts
{
    public interface IItemCollectionService
    {
        List<ItemCollection> GetItemCollections();
        List<ItemCollection> SearchItemCollections(string Name);
        List<Item> GetItemsFromItemCollection(ItemCollection itemCollection);
        List<Item> GetItemsNotFromItemCollection(ItemCollection itemCollection);
        ItemCollection GetItemCollectionById(long id);
        void CreateItemCollection(ItemCollection itemCollection, string FormItems);
        void UpdateItemCollection(ItemCollection item, string FormItems);
        void DeleteItemCollection(long id);
    }
}
