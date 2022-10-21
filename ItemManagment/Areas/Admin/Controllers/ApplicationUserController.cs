using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemManagement.Areas.Admin.Controllers
{
    public class ApplicationUserController : Controller
    {
        // GET: Admin/ApplicationUser
        public ActionResult Index()
        {
            return View();
        }
    }
}