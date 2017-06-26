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
    public class CreateTicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreateTickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Vaga);
            return View(tickets.ToList());
        }

        // GET: CreateTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: CreateTickets/Create
        public ActionResult Create()
        {
            ViewBag.VagaID = new SelectList(db.Vagas, "VagaID", "VagaID");
            return View();
        }

        // POST: CreateTickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,Placa,DataEntrada,VagaID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VagaID = new SelectList(db.Vagas, "VagaID", "VagaID", ticket.VagaID);
            return View(ticket);
        }

        // GET: CreateTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.VagaID = new SelectList(db.Vagas, "VagaID", "VagaID", ticket.VagaID);
            return View(ticket);
        }

        // POST: CreateTickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,Placa,DataEntrada,DataSaida,SegundaVia,MotivoLiberacaoGeral,MotivoSegundaVia,Valor,Liberado,VagaID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VagaID = new SelectList(db.Vagas, "VagaID", "VagaID", ticket.VagaID);
            return View(ticket);
        }

        // GET: CreateTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: CreateTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
