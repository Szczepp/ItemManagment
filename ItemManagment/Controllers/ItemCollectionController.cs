using ItemManagement.DataLayer;
using ItemManagement.DomainModels;
using ItemManagement.ServiceLayer;
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
        public ItemCollectionService _itemCollectionService;
        public ItemCollectionController()
        {
            _itemCollectionService = new ItemCollectionService();
        }
        // GET: ItemCollection
        public ActionResult Index()
        {
            List<ItemCollection> itemCollections = _itemCollectionService.GetItemCollections();
            
            return View(itemCollections);
        }

        /*public ActionResult Create()
        {
            List<Item> Items = _db.Items.ToList();

            return View(Items);
        }*/

        [HttpPost]
        public ActionResult Create(ItemCollection collection)
        {
            _itemCollectionService.CreateItemCollection(collection, Request.Form["Items"]);
            return RedirectToAction("Index");
        }

        public ActionResult Details(long id)
        {
            ItemCollection itemCollection = _itemCollectionService.GetItemCollectionById(id);
            ViewBag.Items = _itemCollectionService.GetItemsFromItemCollection(itemCollection);
            return View(itemCollection);
        }
        public ActionResult Edit(long id)
        {
            ItemCollection itemCollection = _itemCollectionService.GetItemCollectionById(id);
            ViewBag.ItemsInCollection = _itemCollectionService.GetItemsFromItemCollection(itemCollection);
            ViewBag.ItemsNotInCollection = _itemCollectionService.GetItemsNotFromItemCollection(itemCollection);

            return View(itemCollection);
        }


        [HttpPost]
        public ActionResult Edit(ItemCollection collection)
        {
            _itemCollectionService.UpdateItemCollection(collection, Request.Form["Items"]);

            return RedirectToAction("Index");
        }
    }
}