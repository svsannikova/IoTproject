using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RaspisController : Controller
    {
        private SensorDb db = new SensorDb();

        // GET: Raspis
        public ActionResult Index()
        {
            return View(db.Raspis.ToList());
        }

        // GET: Raspis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raspi raspi = db.Raspis.Find(id);
            if (raspi == null)
            {
                return HttpNotFound();
            }
            return View(raspi);
        }

        // GET: Raspis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raspis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaspiId,UserId,Pin1,Pin2,Pin3")] Raspi raspi)
        {
            if (ModelState.IsValid)
            {
                db.Raspis.Add(raspi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raspi);
        }

        // GET: Raspis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raspi raspi = db.Raspis.Find(id);
            if (raspi == null)
            {
                return HttpNotFound();
            }
            return View(raspi);
        }

        // POST: Raspis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaspiId,UserId,Pin1,Pin2,Pin3")] Raspi raspi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raspi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raspi);
        }

        // GET: Raspis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raspi raspi = db.Raspis.Find(id);
            if (raspi == null)
            {
                return HttpNotFound();
            }
            return View(raspi);
        }

        // POST: Raspis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raspi raspi = db.Raspis.Find(id);
            db.Raspis.Remove(raspi);
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
    }
}
