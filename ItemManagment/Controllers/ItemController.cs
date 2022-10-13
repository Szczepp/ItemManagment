using ItemManagement.DomainModels;
using ItemManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemManagement.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            ItemManagement.DataLayer.ItemManagementDbContext db = new ItemManagement.DataLayer.ItemManagementDbContext();
            List<Item> Items = db.Items.ToList();
            return View(Items);
        }
    }
}