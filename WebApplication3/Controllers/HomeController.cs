using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private SaleContext db = new SaleContext();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Agent).Include(s => s.Person).Include(s => s.Agent.City);
            return View(sales.ToList());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var sale = db.Sales.Find(id);
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name", sale.AgentId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", sale.PersonId);
            return PartialView(sale);
        }
        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            db.Entry(sale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        // GET: Sales/Create
        public ActionResult Create()
        {
            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name");
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name");
            return View();
        }

        // POST: Sales/Create
        
        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgentId = new SelectList(db.Agents, "Id", "Name", sale.AgentId);
            ViewBag.PersonId = new SelectList(db.Persons, "Id", "Name", sale.PersonId);
            return View(sale);
        }





        public ActionResult Delete(int? id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Copy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Sale sale = db.Sales.Find(id);
            db.Sales.Add(sale);
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
