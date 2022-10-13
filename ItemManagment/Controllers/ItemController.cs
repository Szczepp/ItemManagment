using ItemManagement;
using ItemManagement.Models;
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
            ItemManagementDbContext db = new ItemManagementDbContext();
            List<Item> Items = db.Items.ToList();
            return View(Items);
        }
    }
}