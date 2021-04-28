using PersonelMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelMVC.ViewModels;

namespace PersonelMVC.Controllers
{

    public class PersonelController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new PersonelDbEntities())
            {
                //personel tablosu ile departman tablosunu joinle
                var model = context.Personel.Include(d => d.Departman).ToList();
                return View(model);
            }
        }

        public ActionResult Yeni()
        {
            using (var context = new PersonelDbEntities())
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = context.Departman.ToList()
                };
                return View("PersonelFormu", model);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Personel personel)
        {
            using (var context = new PersonelDbEntities())
            {
                if (personel.Id == 0)
                {
                    context.Personel.Add(personel);
                }
                else
                {
                    if (personel == null)
                    {
                        return HttpNotFound();
                    }
                    context.Entry(personel).State = EntityState.Modified;
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Update(int id = 0)
        {
            using (var context = new PersonelDbEntities())
            {
                var model = new PersonelFormViewModel()
                {
                    Departmanlar = context.Departman.ToList(),
                    Personel = context.Personel.Find(id)

                };
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View("PersonelFormu", model);
            }
        }

        public ActionResult Delete(int id = 0)
        {
            using (var context = new PersonelDbEntities())
            {
                var result = context.Personel.Find(id);
                if (result == null)
                {
                    return HttpNotFound();
                }
                context.Personel.Remove(result);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult PersonelleriListele(int id = 0)
        {
            using (var context = new PersonelDbEntities())
            {
                var result = context.Personel.Where(m => m.DepartmanId == id).ToList();
                return PartialView(result);
            }

        }

        public int? ToplamMaas()
        {
            using (var context = new PersonelDbEntities())
            {
                return context.Personel.Sum(m => m.Maas);
            }
               
        }

    }
}