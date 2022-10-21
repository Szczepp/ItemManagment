using ItemManagement.DataLayer;
using ItemManagement.DomainModels;
using ItemManagement.Filters;
using ItemManagement.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ItemManagement.Controllers
{
    public class ItemCollectionController : Controller
    {
        public ItemCollectionService _itemCollectionService;
        public ItemService _itemService;
        public ItemCollectionController()
        {
            _itemCollectionService = new ItemCollectionService();
            _itemService = new ItemService();
        }

        public ActionResult Index()
        {
            List<ItemCollection> itemCollections = _itemCollectionService.GetItemCollections();
            
            return View(itemCollections);
        }

        [AuthenticationFilter]
        public ActionResult Create()
        {
            List<Item> Items = _itemService.GetItems();

            return View(Items);
        }

        [AuthenticationFilter]
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
        [AuthenticationFilter]
        public ActionResult Edit(long id)
        {
            ItemCollection itemCollection = _itemCollectionService.GetItemCollectionById(id);
            ViewBag.ItemsInCollection = _itemCollectionService.GetItemsFromItemCollection(itemCollection);
            ViewBag.ItemsNotInCollection = _itemCollectionService.GetItemsNotFromItemCollection(itemCollection);

            return View(itemCollection);
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Edit(ItemCollection collection)
        {
            _itemCollectionService.UpdateItemCollection(collection, Request.Form["Items"]);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter]
        public ActionResult Delete(long id)
        {
            _itemCollectionService.DeleteItemCollection(id);

            return RedirectToAction("Index");
        }
    }
}