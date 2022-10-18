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
        List<Item> GetItemCollections();
        List<Item> SearchItemCollections(string Name);
        Item GetItemCollectionById(int id);
        void CreateItemCollection(Item item);
        void UpdateItemCollection(Item item);
        void DeleteItemCollection(int id);
    }
}
