using ItemManagement;
using ItemManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemManagment.Controllers
{
    public class ItemCollectionController : Controller
    {
        // GET: ItemCollection
        public ActionResult Index()
        {
            ItemManagementDbContext db = new ItemManagementDbContext();
            List<ItemCollection> itemCollections = db.ItemCollections.ToList();
            return View(itemCollections);
        }
    }
}