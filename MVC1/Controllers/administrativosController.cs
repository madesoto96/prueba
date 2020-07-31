using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;

namespace MVC1.Controllers
{
    public class administrativosController : Controller
    {
        private cesdeEntities db = new cesdeEntities();

        // GET: administrativos
        public ActionResult Index()
        {
            return View(db.administrativos.ToList());
        }

        // GET: administrativos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            administrativos administrativos = db.administrativos.Find(id);
            if (administrativos == null)
            {
                return HttpNotFound();
            }
            return View(administrativos);
        }

        // GET: administrativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administrativos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombrepersona,codigopersona,areaadministrativa,telefono")] administrativos administrativos)
        {
            if (ModelState.IsValid)
            {
                db.administrativos.Add(administrativos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrativos);
        }

        // GET: administrativos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            administrativos administrativos = db.administrativos.Find(id);
            if (administrativos == null)
            {
                return HttpNotFound();
            }
            return View(administrativos);
        }

        // POST: administrativos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombrepersona,codigopersona,areaadministrativa,telefono")] administrativos administrativos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrativos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrativos);
        }

        // GET: administrativos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            administrativos administrativos = db.administrativos.Find(id);
            if (administrativos == null)
            {
                return HttpNotFound();
            }
            return View(administrativos);
        }

        // POST: administrativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            administrativos administrativos = db.administrativos.Find(id);
            db.administrativos.Remove(administrativos);
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
