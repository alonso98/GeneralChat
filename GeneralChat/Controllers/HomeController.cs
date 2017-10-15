using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralChat.Controllers
{
    public class HomeController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {
            using (Models.UserContext db = new Models.UserContext())
            {
                ViewBag.Messages = db.Messages.Include("User").ToList();
            }
            return View();
        }

    }
}