using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaJogos.ConnectionDB;

namespace SistemaJogos.Controllers
{
    public class comprasController : Controller
    {
        private sistemaGamesEntities db = new sistemaGamesEntities();

        // GET: compras
        public ActionResult Index()
        {
            var compra = db.compra.Include(c => c.clientes).Include(c => c.jogos);
            return View(compra.ToList());
        }

        // GET: compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: compras/Create
        public ActionResult Create()
        {
            ViewBag.jogos_idjogos = new SelectList(db.clientes, "idclientes", "nome");
            ViewBag.jogos_idjogos = new SelectList(db.jogos, "idjogos", "nome");
            return View();
        }

        // POST: compras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompra,jogos_idjogos,clientes_idclientes,dtCompra,quantidade,valor")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jogos_idjogos = new SelectList(db.clientes, "idclientes", "nome", compra.jogos_idjogos);
            ViewBag.jogos_idjogos = new SelectList(db.jogos, "idjogos", "nome", compra.jogos_idjogos);
            return View(compra);
        }

        // GET: compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.jogos_idjogos = new SelectList(db.clientes, "idclientes", "nome", compra.jogos_idjogos);
            ViewBag.jogos_idjogos = new SelectList(db.jogos, "idjogos", "nome", compra.jogos_idjogos);
            return View(compra);
        }

        // POST: compras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompra,jogos_idjogos,clientes_idclientes,dtCompra,quantidade,valor")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jogos_idjogos = new SelectList(db.clientes, "idclientes", "nome", compra.jogos_idjogos);
            ViewBag.jogos_idjogos = new SelectList(db.jogos, "idjogos", "nome", compra.jogos_idjogos);
            return View(compra);
        }

        // GET: compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compra compra = db.compra.Find(id);
            db.compra.Remove(compra);
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
