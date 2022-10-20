using ItemManagement.DataLayer;
using ItemManagement.DomainModels;
using ItemManagement.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemManagement.RepositoryLayer
{
    public class ItemCollectionRepository : IItemCollectionRepository
    {
        ItemManagementDbContext _db;

        public ItemCollectionRepository()
        {
            _db = new ItemManagementDbContext();
        }
        public void CreateItemCollection(ItemCollection itemCollection, string FormItems)
        {
            List<Item> ItemsList = new List<Item>();
            if (FormItems != null)
            {
                var itemsIdArray = FormItems.Split(',');
                foreach (var id in itemsIdArray)
                {
                    long itemId = long.Parse(id);
                    ItemsList.Add(_db.Items.Where(temp => temp.Id == itemId).FirstOrDefault());
                }
            }
            itemCollection.Items = ItemsList;
            _db.ItemCollections.Add(itemCollection);
            _db.SaveChanges();
            
        }

        public void DeleteItemCollection(long id)
        {
            ItemCollection collection =  _db.ItemCollections.Find(id);
            _db.ItemCollections.Remove(collection);
            _db.SaveChanges();
        }

        public ItemCollection GetItemCollectionById(long id)
        {
            return _db.ItemCollections.Where(temp => temp.Id == id).FirstOrDefault();
        }

        public List<ItemCollection> GetItemCollections()
        {
            return _db.ItemCollections.ToList();
        }
        public List<Item> GetItemsFromItemCollection(ItemCollection itemCollection)
        {
            return itemCollection.Items.ToList();

        } 
        public List<Item> GetItemsNotFromItemCollection(ItemCollection itemCollection)
        {
            var ItemsInCollectionIds = itemCollection.Items.Select(temp => temp.Id).ToArray();
            return _db.Items.Where(temp => !ItemsInCollectionIds.Contains(temp.Id)).ToList();
        }

        public List<ItemCollection> SearchItemCollections(string Name)
        {
            throw new NotImplementedException();
        }

        public void UpdateItemCollection(ItemCollection itemCollection, string FormItems)
        {
            ItemCollection existingItemCollection = _db.ItemCollections.Where(temp => temp.Id == itemCollection.Id).FirstOrDefault();
            var existingCollectionItems = this.GetItemsFromItemCollection(existingItemCollection);
            foreach(var item in existingCollectionItems)
            {
                var id = item.Id;
                existingItemCollection.Items.Remove(item);
            }
            if (FormItems != null)
            {
                var itemsIdArray = FormItems.Split(',');
                foreach (var itemId in itemsIdArray)
                {
                    long longItemId = long.Parse(itemId);
                    existingItemCollection.Items.Add(_db.Items.Where(temp => temp.Id == longItemId).FirstOrDefault());
                }
            }

            _db.Entry(existingItemCollection).CurrentValues.SetValues(itemCollection);
            _db.SaveChanges();
        }
    }
}
