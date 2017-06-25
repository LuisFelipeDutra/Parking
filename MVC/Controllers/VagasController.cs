using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using MVC.Models;

namespace MVC.Controllers
{
    public class VagasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vagas
        public ActionResult Index()
        {
            return View(db.Vagas.ToList());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VagasID,Ocupada")] Vaga vagas)
        {
            if (ModelState.IsValid)
            {
                db.Vagas.Add(vagas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vagas);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VagasID,Ocupada")] Vaga vagas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vagas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vagas);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vagas = db.Vagas.Find(id);
            if (vagas == null)
            {
                return HttpNotFound();
            }
            return View(vagas);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaga vagas = db.Vagas.Find(id);
            db.Vagas.Remove(vagas);
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
