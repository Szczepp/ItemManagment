using ItemManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemManagement.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeController : Controller
    {
        [AuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}