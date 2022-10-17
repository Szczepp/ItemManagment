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
        ItemManagementDbContext _db;
        public ItemController()
        {
            _db = new ItemManagementDbContext();
        }
        // GET: Item
        public ActionResult Index()
        {
            List<Item> Items = _db.Items.Where(temp => temp.Name != null).ToList();
            return View(Items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (item == null)
            {
                return View();
            }
            _db.Items.Add(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
            var item = _db.Items.Where(temp => temp.Id == Id).FirstOrDefault();
            return View(item);
        }
    }
}