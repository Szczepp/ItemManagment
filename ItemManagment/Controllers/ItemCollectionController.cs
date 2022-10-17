using ItemManagement.DataLayer;
using ItemManagement.DomainModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
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
            _db.ItemCollections.Add(collection);
            var itemsIdArray = Request.Form["Items"].Split(',');
            List<Item> ItemsList = new List<Item>();
            foreach(var id in itemsIdArray)
            {
                long itemId = long.Parse(id);
                ItemsList.Add(_db.Items.Where(temp => temp.Id == itemId).FirstOrDefault());
            }

            collection.Items = ItemsList;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            ItemCollection itemCollection = _db.ItemCollections.Where(temp => temp.Id == id).FirstOrDefault();
            ViewBag.Items = itemCollection.Items.ToList();
            return View(itemCollection);
        }
    }
}