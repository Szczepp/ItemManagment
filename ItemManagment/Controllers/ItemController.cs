using ItemManagement.DomainModels;
using ItemManagement.DataLayer;
using ItemManagement.ServiceLayer;
using ItemManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemManagement.Controllers
{
    public class ItemController : Controller
    {
        ItemService _itemService;
        public ItemController()
        {
            _itemService = new ItemService();
        }
        public ActionResult Index()
        { 
            List<Item> Items = _itemService.GetItems();

            return View(Items);
        }

        [AuthenticationFilter]
        public ActionResult Create()
        {
            return View();
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (item == null)
            {
                return View();
            }
            _itemService.CreateItem(item);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(long Id)
        {
            var item = _itemService.GetItemById(Id);
            return View(item);
        }

        [AuthenticationFilter]
        public ActionResult Edit(long id)
        {
            Item item = _itemService.GetItemById(id);
            return View(item);
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            _itemService.UpdateItem(item);
            return RedirectToAction("Index");
        }

        [AuthenticationFilter]
        public ActionResult Delete(long id)
        {
            _itemService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}