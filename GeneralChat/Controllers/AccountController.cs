using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using GeneralChat.Models;

namespace GeneralChat.Controllers
{
    public class AccountController : Controller
    {
        UserContext db = new UserContext();
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!db.Users.Any(u => u.Name == model.Name))
            {
                db.Users.Add(new User() { Name = model.Name, Online = true });
                db.SaveChanges();
            }
            else
            {
                if (db.Users.FirstOrDefault(u => u.Name == model.Name).Online == false)
                {
                    db.Users.FirstOrDefault(u => u.Name == model.Name).Online = true;
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь под данным именем уже онлайн. Выберите, пожалуйста, другое имя для входа");
                    return View("Login");
                }
            }
            User user = db.Users.FirstOrDefault(u => u.Name == model.Name);
            FormsAuthentication.SetAuthCookie(user.Name, true);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult LoginOff()
        {
            db.Users.FirstOrDefault(u => u.Name == User.Identity.Name).Online = false;
            db.SaveChanges();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}