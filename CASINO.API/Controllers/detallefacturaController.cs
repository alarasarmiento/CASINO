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

namespace CASINO.API.Controllers
{
    public class detallefacturaController : ApiController
    {
        private casinoEntities db = new casinoEntities();

        // GET: api/detallefactura
        public IQueryable<detalle_factura> Getdetalle_factura()
        {
            return db.detalle_factura;
        }

        // GET: api/detallefactura/5
        [ResponseType(typeof(detalle_factura))]
        public IHttpActionResult Getdetalle_factura(int id)
        {
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return NotFound();
            }

            return Ok(detalle_factura);
        }

        // PUT: api/detallefactura/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdetalle_factura(int id, detalle_factura detalle_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle_factura.codigo_detalle)
            {
                return BadRequest();
            }

            db.Entry(detalle_factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detalle_facturaExists(id))
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

        // POST: api/detallefactura
        [ResponseType(typeof(detalle_factura))]
        public IHttpActionResult Postdetalle_factura(detalle_factura detalle_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.detalle_factura.Add(detalle_factura);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = detalle_factura.codigo_detalle }, detalle_factura);
        }

        // DELETE: api/detallefactura/5
        [ResponseType(typeof(detalle_factura))]
        public IHttpActionResult Deletedetalle_factura(int id)
        {
            detalle_factura detalle_factura = db.detalle_factura.Find(id);
            if (detalle_factura == null)
            {
                return NotFound();
            }

            db.detalle_factura.Remove(detalle_factura);
            db.SaveChanges();

            return Ok(detalle_factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool detalle_facturaExists(int id)
        {
            return db.detalle_factura.Count(e => e.codigo_detalle == id) > 0;
        }
    }
}