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
    public class ElevsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Elevs
        public ActionResult Index()
        {
            var elever = db.Elever.Include(e => e.Skole);
            return View(elever.ToList());
        }

        // GET: Elevs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elev elev = db.Elever.Find(id);
            if (elev == null)
            {
                return HttpNotFound();
            }
            return View(elev);
        }

        // GET: Elevs/Create
        public ActionResult Create()
        {
            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn");
            return View();
        }

        // POST: Elevs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ElevId,Fornavn,Etternavn,Trinn,Klasse,Telefon,SkoleId")] Elev elev)
        {
            if (ModelState.IsValid)
            {
                db.Elever.Add(elev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn", elev.SkoleId);
            return View(elev);
        }

        // GET: Elevs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elev elev = db.Elever.Find(id);
            if (elev == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn", elev.SkoleId);
            return View(elev);
        }

        // POST: Elevs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ElevId,Fornavn,Etternavn,Trinn,Klasse,Telefon,SkoleId")] Elev elev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SkoleId = new SelectList(db.Skoler, "SkoleId", "SkoleNavn", elev.SkoleId);
            return View(elev);
        }

        // GET: Elevs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elev elev = db.Elever.Find(id);
            if (elev == null)
            {
                return HttpNotFound();
            }
            return View(elev);
        }

        // POST: Elevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elev elev = db.Elever.Find(id);
            db.Elever.Remove(elev);
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
