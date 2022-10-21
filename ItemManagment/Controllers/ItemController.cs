using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItemManagement.DomainModels;
using ItemManagement.ServiceLayer;

namespace ItemManagement.Controllers
{
    public class ItemController : Controller
    {
        ItemService _itemService;
        public ItemController()
        {
            _itemService = new ItemService();
        }
        // GET: Item
        public ActionResult Index()
        {
            var items = _itemService.GetItems();
            return View(items);
        }
        public ActionResult Details(long id)
        {
            var item = _itemService.GetItemById(id);
            return View(item);
        }
    }
}