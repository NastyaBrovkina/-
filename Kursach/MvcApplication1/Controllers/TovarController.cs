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
    public class TovarController : Controller
    {
        private ComputersEntities5 db = new ComputersEntities5();

        //
        // GET: /Tovar/

        public ActionResult Index()
        {
            var tovars = db.Tovars.Include(t => t.Sklad);
            return View(tovars.ToList());
        }

        //
        // GET: /Tovar/Details/5

        public ActionResult Details(int id = 0)
        {
            Tovar tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            return View(tovar);
        }

        //
        // GET: /Tovar/Create

        public ActionResult Create()
        {
            ViewBag.idTovara = new SelectList(db.Sklads, "idTovara", "nazvanie");
            return View();
        }

        //
        // POST: /Tovar/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tovar tovar)
        {
            if (ModelState.IsValid)
            {
                db.Tovars.Add(tovar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTovara = new SelectList(db.Sklads, "idTovara", "nazvanie", tovar.idTovara);
            return View(tovar);
        }

        //
        // GET: /Tovar/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tovar tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTovara = new SelectList(db.Sklads, "idTovara", "nazvanie", tovar.idTovara);
            return View(tovar);
        }

        //
        // POST: /Tovar/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tovar tovar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tovar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTovara = new SelectList(db.Sklads, "idTovara", "nazvanie", tovar.idTovara);
            return View(tovar);
        }

        //
        // GET: /Tovar/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tovar tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            return View(tovar);
        }

        //
        // POST: /Tovar/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tovar tovar = db.Tovars.Find(id);
            db.Tovars.Remove(tovar);
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