using ItemManagement.DataLayer;
using ItemManagement.DomainModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace ItemManagement.Controllers
{
    public class ItemCollectionController : Controller
    {
        public ItemManagementDbContext _db;
        public ItemCollectionController()
        {
            _db = new ItemManagementDbContext();
        }
        // GET: ItemCollection
        public ActionResult Index()
        {
            List<ItemCollection> itemCollections = _db.ItemCollections.ToList();
            
            return View(itemCollections);
        }

        public ActionResult Create()
        {
            List<Item> Items = _db.Items.ToList();

            return View(Items);
        }

        [HttpPost]
        public ActionResult Create(ItemCollection collection)
        {
            List<Item> ItemsList = new List<Item>();
            if (Request.Form["Items"] != null)
            {
                var itemsIdArray = Request.Form["Items"].Split(',');
                foreach(var id in itemsIdArray)
                {
                    long itemId = long.Parse(id);
                    ItemsList.Add(_db.Items.Where(temp => temp.Id == itemId).FirstOrDefault());
                }
            }
            collection.Items = ItemsList;
            _db.ItemCollections.Add(collection);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            ItemCollection itemCollection = _db.ItemCollections.Where(temp => temp.Id == id).FirstOrDefault();
            ViewBag.Items = itemCollection.Items.ToList();
            return View(itemCollection);
        }
        public ActionResult Edit(long id)
        {
            ItemCollection itemCollection = _db.ItemCollections.Where(temp => temp.Id == id).FirstOrDefault();
            ViewBag.ItemsInCollection = itemCollection.Items.ToList();

            var ItemsInCollectionIds = itemCollection.Items.Select(temp => temp.Id).ToArray();

            ViewBag.ItemsNotInCollection = _db.Items.Where(temp => !ItemsInCollectionIds.Contains(temp.Id)).ToList();

            return View(itemCollection);
        }


        [HttpPost]
        public ActionResult Edit(ItemCollection collection, long id)
        {
            ItemCollection existingItemCollection = _db.ItemCollections.Find(id);

            if(Request.Form["Items"] != null)
            {
                var itemsIdArray = Request.Form["Items"].Split(',');
                foreach (var itemId in itemsIdArray)
                {
                    long longItemId = long.Parse(itemId);
                    existingItemCollection.Items.Add(_db.Items.Where(temp => temp.Id == longItemId).FirstOrDefault());
                }
            }

            _db.Entry(existingItemCollection).CurrentValues.SetValues(collection);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}