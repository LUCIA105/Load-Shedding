using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoadsheddingSystem.Models;
using Rotativa;

namespace LoadsheddingSystem.Controllers
{
    public class LoadsheddingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Loadsheddings
        public ActionResult Index()
        {
            return View(db.Loadsheddings.ToList());
        }

        // GET: Loadsheddings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loadshedding loadshedding = db.Loadsheddings.Find(id);
            if (loadshedding == null)
            {
                return HttpNotFound();
            }
            return View(loadshedding);
        }

        // GET: Loadsheddings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loadsheddings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoadsheddingId,BlockNumber,Date,StartTime,EndTime,Stage")] Loadshedding loadshedding)
        {
            if (ModelState.IsValid)
            {
                if (loadshedding.Date < DateTime.Today)
                {
                    ModelState.AddModelError("Date", "You cannot create a schedule for a date that has already passed");
                    return View();
                }
                if (loadshedding.StartTime >= loadshedding.EndTime) 
                {
                    ModelState.AddModelError("StartTime", "You cannot have a start time greater than your end time");
                    return View();
                }

                db.Loadsheddings.Add(loadshedding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loadshedding);
        }

        // GET: Loadsheddings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loadshedding loadshedding = db.Loadsheddings.Find(id);
            if (loadshedding == null)
            {
                return HttpNotFound();
            }
            return View(loadshedding);
        }

        // POST: Loadsheddings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoadsheddingId,BlockNumber,Date,StartTime,EndTime,Stage")] Loadshedding loadshedding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loadshedding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loadshedding);
        }

        // GET: Loadsheddings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loadshedding loadshedding = db.Loadsheddings.Find(id);
            if (loadshedding == null)
            {
                return HttpNotFound();
            }
            return View(loadshedding);
        }

        // POST: Loadsheddings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loadshedding loadshedding = db.Loadsheddings.Find(id);
            db.Loadsheddings.Remove(loadshedding);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult IndexById(int id)
        {
            var emp = db.Loadsheddings.Where(e => e.LoadsheddingId == id).First();
            return View(emp);
        }
        public ActionResult PrintById(int id)
        {
            var report = new ActionAsPdf("IndexById", new { id = id });
            return report;
        }

    }
}
