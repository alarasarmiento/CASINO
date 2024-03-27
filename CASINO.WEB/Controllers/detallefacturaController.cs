using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CASINO.WEB;

namespace CASINO.WEB.Controllers
{
    public class detallefacturaController : Controller
    {
        private casinoEntities db = new casinoEntities();

        // GET: detallefactura
        public ActionResult Index()
        {
            var detalle_factura = db.detalle_factura.Include(d => d.factura).Include(d => d.producto);
            return View(detalle_factura.ToList());
        }

        // GET: detallefactura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // GET: detallefactura/Create
        public ActionResult Create()
        {
            ViewBag.numero_factura = new SelectList(db.factura, "numero_factura", "numero_factura");
            ViewBag.codigo_producto = new SelectList(db.producto, "codigo_producto", "nombre");
            return View();
        }

        // POST: detallefactura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo_detalle,numero_factura,codigo_producto,cantidad,precio,subtotal,fecha_creacion")] detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.detalle_factura.Add(detalle_factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numero_factura = new SelectList(db.factura, "numero_factura", "numero_factura", detalle_factura.numero_factura);
            ViewBag.codigo_producto = new SelectList(db.producto, "codigo_producto", "nombre", detalle_factura.codigo_producto);
            return View(detalle_factura);
        }

        // GET: detallefactura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.numero_factura = new SelectList(db.factura, "numero_factura", "numero_factura", detalle_factura.numero_factura);
            ViewBag.codigo_producto = new SelectList(db.producto, "codigo_producto", "nombre", detalle_factura.codigo_producto);
            return View(detalle_factura);
        }

        // POST: detallefactura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo_detalle,numero_factura,codigo_producto,cantidad,precio,subtotal,fecha_creacion")] detalle_factura detalle_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numero_factura = new SelectList(db.factura, "numero_factura", "numero_factura", detalle_factura.numero_factura);
            ViewBag.codigo_producto = new SelectList(db.producto, "codigo_producto", "nombre", detalle_factura.codigo_producto);
            return View(detalle_factura);
        }

        // GET: detallefactura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return HttpNotFound();
            }
            return View(detalle_factura);
        }

        // POST: detallefactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            db.detalle_factura.Remove(detalle_factura);
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
