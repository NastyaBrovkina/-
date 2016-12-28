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
    public class KorzinaController : Controller
    {
        private ComputersEntities5 db = new ComputersEntities5();

        //
        // GET: /Korzina/

        public ActionResult Index()
        {
            var korzinas = db.Korzinas.Include(k => k.Sklad);
            return View(korzinas.ToList());
        }

        //
       


        //
        // GET: /Korzina/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Korzina korzina = db.Korzinas.Find(id);
            if (korzina == null)
            {
                return HttpNotFound();
            }
            return View(korzina);
        }

        public ActionResult Buy(Korzina korzina, int id)
        {
            korzina = db.Korzinas.Find(id);
            if (korzina == null)
            {
                return HttpNotFound();

            }

            return View(korzina);
        }

        //
        // POST: /Korzina/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korzina korzina = db.Korzinas.Find(id);
            db.Korzinas.Remove(korzina);
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