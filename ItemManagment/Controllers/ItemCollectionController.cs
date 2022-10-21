using ItemManagement.ServiceLayer;
using ItemManagement.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Details(long id)
        {
            ItemCollection itemCollection = _itemCollectionService.GetItemCollectionById(id);
            ViewBag.Items = _itemCollectionService.GetItemsFromItemCollection(itemCollection);

            return View(itemCollection);
        }
    }
}