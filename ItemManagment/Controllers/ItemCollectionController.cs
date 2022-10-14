using ItemManagement.DataLayer;
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
        // GET: ItemCollection
        public ActionResult Index()
        {
            ItemManagement.DataLayer.ItemManagementDbContext db = new ItemManagement.DataLayer.ItemManagementDbContext();
            List<ItemCollection> itemCollections = db.ItemCollections.ToList();
            return View(itemCollections);
        }
    }
}