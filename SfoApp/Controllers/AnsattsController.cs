using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SfoApp.Models;

namespace SfoApp.Controllers
{
    public class AnsattsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ansatts
        public ActionResult Index()
        {
            var ansatte = db.Ansatte.Include(a => a.Skole);
            return View(ansatte.ToList());
        }

        // GET: Ansatts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ansatt ansatt = db.Ansatte.Find(id);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            return View(ansatt);
        }

        // GET: Ansatts/Create
        public ActionResult Create()
        {
            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn");
            return View();
        }

        // POST: Ansatts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnsattId,Fornavn,Etternavn,SkoleId")] Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                db.Ansatte.Add(ansatt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn", ansatt.SkoleId);
            return View(ansatt);
        }

        // GET: Ansatts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ansatt ansatt = db.Ansatte.Find(id);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn", ansatt.SkoleId);
            return View(ansatt);
        }

        // POST: Ansatts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnsattId,Fornavn,Etternavn,SkoleId")] Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ansatt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn", ansatt.SkoleId);
            return View(ansatt);
        }

        // GET: Ansatts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ansatt ansatt = db.Ansatte.Find(id);
            if (ansatt == null)
            {
                return HttpNotFound();
            }
            return View(ansatt);
        }

        // POST: Ansatts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ansatt ansatt = db.Ansatte.Find(id);
            db.Ansatte.Remove(ansatt);
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
