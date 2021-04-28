
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonelMVC.Models.EntityFramework;
using PersonelMVC.ViewModels;

namespace PersonelMVC.Controllers
{
    
    public class DepartmanController : Controller
    {
        [OutputCache(Duration =30)]
        public ActionResult Index()
        {
            using (var context = new PersonelDbEntities())
            {
                var model = context.Departman.ToList();
                return View(model);
            }
        }

        public ActionResult Yeni()
        {
            return View("DepartmanFormu");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Departman departman)
        {
            using (var context = new PersonelDbEntities())
            {
                MesajViewModel model = new MesajViewModel();
                if (departman.Id == 0)
                {
                    context.Departman.Add(departman);
                    model.Mesaj = departman.Ad + " :başarıyla eklendi";
                }
                
                else
                {
                    var res = context.Departman.Find(departman.Id);
                    if (res == null)
                    {
                        return HttpNotFound();
                    }
                    res.Ad = departman.Ad;
                    model.Mesaj = departman.Ad + " :başarıyla güncellendi";

                }
                context.SaveChanges();
                model.Status = true;
                model.LinkText = "Departman Listesi";
                model.Url = "/Departman";
                return View("_Mesaj",model);
            }
        }

        public ActionResult Update(int id = 0)
        {
            using (var context = new PersonelDbEntities())
            {
                var result = context.Departman.Find(id);
                if (result == null)
                {
                    return HttpNotFound();
                }
                return View("DepartmanFormu", result);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            using (var context = new PersonelDbEntities())
            {
                var result = context.Departman.Find(id);
                if (result == null)
                {
                    return HttpNotFound();
                }
                context.Departman.Remove(result);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}