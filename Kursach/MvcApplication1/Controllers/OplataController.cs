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
    public class OplataController : Controller
    {
        private ComputersEntities5 db = new ComputersEntities5();

   
      

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Oplata/Details/5

        public ActionResult Details(int id = 0)
        {
            Oplata oplata = db.Oplatas.Find(id);
            if (oplata == null)
            {
                return HttpNotFound();
            }
            return View(oplata);
        }

        //
        // GET: /Oplata/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Oplata/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Oplata oplata,int schet)
        {
            
            if (oplata != null ) 
            {
                return this.Content("Оплачено") ;

            }
            else { 

            return this.Content("Повторите оплату");
            }
        }

        //
        // GET: /Oplata/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Oplata oplata = db.Oplatas.Find(id);
            if (oplata == null)
            {
                return HttpNotFound();
            }
            return View(oplata);
        }

        //
        // POST: /Oplata/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Oplata oplata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oplata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oplata);
        }

        //
        // GET: /Oplata/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Oplata oplata = db.Oplatas.Find(id);
            if (oplata == null)
            {
                return HttpNotFound();
            }
            return View(oplata);
        }

        //
        // POST: /Oplata/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oplata oplata = db.Oplatas.Find(id);
            db.Oplatas.Remove(oplata);
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