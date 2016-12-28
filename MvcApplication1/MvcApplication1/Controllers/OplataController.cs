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

    /*    public bool Plata(string s, int sum)
        {
            Random rnd = new Random();
            Oplata opl = new Oplata();
            opl.Schet = s;
            opl.Balanse = rnd.Next(0, 10000);

            Oplata o = new Oplata();
            o.Schet = "0000";
            o.Balanse = 0;
            if (opl.Schet.Equals(o.Schet))
            {
                return false;
            }
            else
            {
                if (opl.Balanse >= sum)
                {
                    opl.Balanse = opl.Balanse - sum;
                    o.Balanse = opl.Balanse + sum;
                    return true;
                }
            }
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

     /*   public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/
        //
        // GET: /Oplata/

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
            oplata = db.Oplatas.Where(o => o.Schet == schet).FirstOrDefault();
           // oplata = db.Oplatas.Find(schet);
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