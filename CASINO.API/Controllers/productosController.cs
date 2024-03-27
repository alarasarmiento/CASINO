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
    public class productosController : ApiController
    {
        private casinoEntities db = new casinoEntities();

        // GET: api/productos
        public IQueryable<producto> Getproducto()
        {
            return db.producto;
        }

        // GET: api/productos/5
        [ResponseType(typeof(producto))]
        public IHttpActionResult Getproducto(int id)
        {
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproducto(int id, producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.codigo_producto)
            {
                return BadRequest();
            }

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productoExists(id))
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

        // POST: api/productos
        [ResponseType(typeof(producto))]
        public IHttpActionResult Postproducto(producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.producto.Add(producto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = producto.codigo_producto }, producto);
        }

        // DELETE: api/productos/5
        [ResponseType(typeof(producto))]
        public IHttpActionResult Deleteproducto(int id)
        {
            producto producto = db.producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.producto.Remove(producto);
            db.SaveChanges();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool productoExists(int id)
        {
            return db.producto.Count(e => e.codigo_producto == id) > 0;
        }
    }
}