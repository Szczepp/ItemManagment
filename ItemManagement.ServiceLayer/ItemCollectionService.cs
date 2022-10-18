using ItemManagement.DomainModels;
using ItemManagement.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemManagement.RepositoryLayer;

namespace ItemManagement.ServiceLayer
{
    public class ItemCollectionService : IItemCollectionService
    {
        ItemCollectionRepository _itemCollectionRepo;

        public ItemCollectionService()
        {
            _itemCollectionRepo = new ItemCollectionRepository();
        }
        public void CreateItemCollection(ItemCollection itemCollection, string FormItems)
        {
            _itemCollectionRepo.CreateItemCollection(itemCollection, FormItems);
        }

        public void DeleteItemCollection(long id)
        {
            _itemCollectionRepo.DeleteItemCollection(id);
        }

        public ItemCollection GetItemCollectionById(long id)
        {
            return _itemCollectionRepo.GetItemCollectionById(id);
        }

        public List<ItemCollection> GetItemCollections()
        {
            return _itemCollectionRepo.GetItemCollections();
        }
        public List<Item> GetItemsFromItemCollection(ItemCollection itemCollection)
        {
            return _itemCollectionRepo.GetItemsFromItemCollection(itemCollection);
        }
        public List<Item> GetItemsNotFromItemCollection(ItemCollection itemCollection)
        {
            return _itemCollectionRepo.GetItemsNotFromItemCollection(itemCollection);
        }

        public List<ItemCollection> SearchItemCollections(string Name)
        {
            throw new NotImplementedException();
        }

        public void UpdateItemCollection(ItemCollection itemCollection, string FormItems)
        {
            _itemCollectionRepo.UpdateItemCollection(itemCollection, FormItems);
        }
    }
}
