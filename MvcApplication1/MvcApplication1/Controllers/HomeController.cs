using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        ComputersEntities5 db = new ComputersEntities5();
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var tovars = from s in db.Tovars
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tovars = tovars.Where(t => t.Sklad.nazvanie.ToUpper().Contains(searchString.ToUpper())
                                       || t.proizvoditel.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    tovars = tovars.OrderByDescending(t => t.Sklad.nazvanie);
                    break;
                
                default:
                    tovars = tovars.OrderBy(t => t.proizvoditel);
                    break;
            } 
            return View(tovars.ToList());
        }

        public ActionResult AddKorz(int id=0)
        {
            Tovar tovar = db.Tovars.Find(id);
            
            if (tovar == null)
            {
                return HttpNotFound();
            }

            return View(tovar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddKorz(Korzina korzina)
        {
            
            Session["Korzina"] = korzina;
            if (ModelState.IsValid)
            {
                Session["Korzina"] = korzina;
                db.Korzinas.Add(korzina);

                
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            
            return View(korzina);
        }
      
        public ActionResult Details(int id = 0)
        {
            Tovar tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            return View(tovar);
        }
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
           
            ViewBag.idTovara = new SelectList(db.Sklads, "idTovara", "nazvanie");
            return View();
        }

        // POST: Tovars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tovar tovar)
        {
           Tovar tovar2 = db.Tovars.Where(m => m.idTovara==tovar.idTovara).FirstOrDefault();
           if (tovar2 == null)
           {

               if (ModelState.IsValid)
               {
                   db.Tovars.Add(tovar);
                   db.SaveChanges();
                   return RedirectToAction("Index");
               }

               ViewBag.idTovara = new SelectList(db.Sklads, "idTovara", "nazvanie", tovar.idTovara);

           }
           else
           {
               return RedirectToAction("Index");
           }
                return View(tovar);
             
        }

       
        // GET: Tovars/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Tovar tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            
            return View(tovar);
        }
        //
        // POST: /Tovar/Edit/5
        [Authorize(Roles = "admin")]
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
            
            return View(tovar);
        }
        
        public ActionResult Buy(Tovar tovar, int id)
        {
            tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
               return HttpNotFound();
                
            }
            
            return View(tovar);
        }
        
        // GET: Tovars/Delete/5
        [Authorize(Roles="admin")]
        public ActionResult Delete(int id = 0)
        {
            Tovar tovar = db.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            return View(tovar);
        }
       
        // POST: Tovars/Delete/5
        [Authorize(Roles = "admin")]
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
        // GET: Tovars/Paid/5
        //  public ActionResult Paid()
        //   {

        //  }
        // POST: Tovars/Paid/5
        //  public ActionResult Paid()
        //   {

        //  }
       
        public ActionResult About()
        {
            
            return View();
        }
        

        public ActionResult Contact()
        {
            

            return View();
        }
        
    }
}
