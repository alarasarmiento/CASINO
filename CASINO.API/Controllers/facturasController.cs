using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CASINO.API;
using CASINO.API.Models;

namespace CASINO.API.Controllers
{
    public class facturasController : ApiController
    {
        private casinoEntities db = new casinoEntities();

        // GET: api/facturas
        public List<Factura> Getfactura()
        {
            var lista = db.factura;

            List<Factura> facturas = new List<Factura>();
            foreach(var row in lista)
            {
                Factura _factura = new Factura();
                _factura.numero_factura = row.numero_factura;
                _factura.cliente_asociado = Convert.ToInt32(row.cliente_asociado);
                _factura.total_factura = Convert.ToInt32(row.total_factura);
                _factura.fecha_factura = Convert.ToDateTime(row.fecha_factura);
                facturas.Add(_factura);
            }
            return facturas;
        }

        // GET: api/facturas/5
        [ResponseType(typeof(Factura))]
        public IHttpActionResult Getfactura(int id)
        {
            factura factura = db.factura.Find(id);

            if (factura == null)
            {
                return NotFound();
            }

            Factura _factura = new Factura();
            _factura.numero_factura = factura.numero_factura;
            _factura.cliente_asociado = Convert.ToInt32(factura.cliente_asociado);
            _factura.total_factura = Convert.ToInt32(factura.total_factura);
            _factura.fecha_factura = Convert.ToDateTime(factura.fecha_factura);

            return Ok(_factura);
        }

        // PUT: api/facturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfactura(int id, factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factura.numero_factura)
            {
                return BadRequest();
            }

            db.Entry(factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!facturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/facturas
        [ResponseType(typeof(factura))]
        public IHttpActionResult Postfactura(factura factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.factura.Add(factura);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (facturaExists(factura.numero_factura))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = factura.numero_factura }, factura);
        }

        // DELETE: api/facturas/5
        [ResponseType(typeof(factura))]
        public IHttpActionResult Deletefactura(int id)
        {
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return NotFound();
            }

            db.factura.Remove(factura);
            db.SaveChanges();

            return Ok(factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool facturaExists(int id)
        {
            return db.factura.Count(e => e.numero_factura == id) > 0;
        }
    }
}