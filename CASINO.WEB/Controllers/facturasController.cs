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
    public class facturasController : Controller
    {
        private casinoEntities db = new casinoEntities();
        private Servicios.ClienteServicio clienteServicio = new Servicios.ClienteServicio();
        private Servicios.FacturaServicio facturaServicio = new Servicios.FacturaServicio();

        // GET: facturas
        public ActionResult Index()
        {
            return View(facturaServicio.GetFacturas()); 
        }

        // GET: facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            factura factura = facturaServicio.GetFactura(id);
            List<detalle_factura> detalle_factura = db.detalle_factura.Where(x => x.numero_factura == id).ToList();

            if (factura == null)
            {
                return HttpNotFound();
            }

            ViewBag.detalle_factura = detalle_factura;
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            List<cliente> clientes = clienteServicio.GetClientes();
            ViewBag.cliente_asociado = new SelectList(clientes, "rut", "nombre");
            return View();
        }

        // POST: facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numero_factura,cliente_asociado,total_factura,fecha_factura")] factura factura)
        {
            
            if (ModelState.IsValid)
            {
                string resultado = facturaServicio.PostFactura(factura.numero_factura, factura);
                return RedirectToAction("Index");
            }
                        
            List<cliente> clientes = clienteServicio.GetClientes();
            ViewBag.cliente_asociado = new SelectList(clientes, "rut", "nombre");

            return View(factura);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            factura factura = facturaServicio.GetFactura(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
                        
            List<cliente> clientes = clienteServicio.GetClientes();

            ViewBag.cliente_asociado = new SelectList(clientes, "rut", "nombre", factura.cliente_asociado);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numero_factura,cliente_asociado,total_factura,fecha_factura")] factura factura)
        {
            if (ModelState.IsValid)
            {
                string resultado = facturaServicio.PutFactura(factura.numero_factura, factura);
                return RedirectToAction("Index");
            }

            List<cliente> clientes = clienteServicio.GetClientes();
            ViewBag.cliente_asociado = new SelectList(clientes, "rut", "nombre", factura.cliente_asociado);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = facturaServicio.GetFactura(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            string resultado = facturaServicio.DeleteFactura(id);
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
