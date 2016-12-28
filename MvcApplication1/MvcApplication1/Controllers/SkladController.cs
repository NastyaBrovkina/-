using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class SkladController : Controller
    {
        
        private ComputersEntities5 db = new ComputersEntities5();

        //
        // GET: /Sklad/

        public ActionResult Index()
        {
            return View(db.Sklads.ToList());
        }

        

        //
        // GET: /Sklad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Sklad/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sklad sklad)
        {
            Sklad d = db.Sklads.Where(s => s.nazvanie == sklad.nazvanie).FirstOrDefault();
            if (d != null)
                return RedirectToAction("Index");

            else
            {
                if (ModelState.IsValid)
                {
                    db.Sklads.Add(sklad);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(sklad);
        }

        //
        // GET: /Sklad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sklad sklad = db.Sklads.Find(id);
            if (sklad == null)
            {
                return HttpNotFound();
            }
            return View(sklad);
        }

        //
        // POST: /Sklad/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sklad sklad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sklad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sklad);
        }

        //
        // GET: /Sklad/Delete/5

        public ActionResult Delete(int id = 0)
        {
           
            Sklad sklad = db.Sklads.Find(id);
            if  (sklad == null)
            {
                return HttpNotFound();
            }
            return View(sklad);

        }

        //
        // POST: /Sklad/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IQueryable<Tovar> tovs = from o in db.Tovars where o.idTovara == id select o;
            Sklad sklad = db.Sklads.Find(id);
            foreach (Tovar tov in tovs)
            {
                db.Tovars.Remove(tov);
            }
            
            
            db.Sklads.Remove(sklad);
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}