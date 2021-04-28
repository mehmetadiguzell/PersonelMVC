using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PersonelMVC.Controllers
{
   
    public class SecurityController : Controller
    {
        
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Kullanici kullanici)
        {
            using (var context = new PersonelDbEntities())
            {
                var result = context.Kullanici.FirstOrDefault(m => m.Ad == kullanici.Ad && m.Sifre == kullanici.Sifre);
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(kullanici.Ad, false);
                    return RedirectToAction("Index","Departman");
                }

                ViewBag.Error="Giriş başarısız";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}