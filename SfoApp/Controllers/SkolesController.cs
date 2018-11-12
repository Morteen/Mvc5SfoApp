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
    public class SkolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Skoles
        public ActionResult Index()
        {
            return View(db.Skoler.ToList());
        }

        // GET: Skoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skole skole = db.Skoler.Find(id);
            if (skole == null)
            {
                return HttpNotFound();
            }
            return View(skole);
        }

        // GET: Skoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkoleId,SkoleNavn")] Skole skole)
        {
            if (ModelState.IsValid)
            {
                db.Skoler.Add(skole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skole);
        }

        // GET: Skoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skole skole = db.Skoler.Find(id);
            if (skole == null)
            {
                return HttpNotFound();
            }
            return View(skole);
        }

        // POST: Skoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkoleId,SkoleNavn")] Skole skole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skole);
        }

        // GET: Skoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skole skole = db.Skoler.Find(id);
            if (skole == null)
            {
                return HttpNotFound();
            }
            return View(skole);
        }

        // POST: Skoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skole skole = db.Skoler.Find(id);
            db.Skoler.Remove(skole);
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
