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
    public class clientesController : ApiController
    {
        private casinoEntities db = new casinoEntities();

        // GET: api/clientes
        public List<Cliente> Getcliente()
        {
            var lista = db.cliente;

            List<Cliente> clientes = new List<Cliente>();
            

            foreach (var row in lista)
            {
                Cliente _cliente = new Cliente();
                _cliente.rut = row.rut;
                _cliente.dv = row.dv;
                _cliente.nombre = row.nombre;
                _cliente.apellido = row.apellido;
                _cliente.telefono = row.telefono;
                _cliente.correo = row.correo;
                _cliente.fecha_creacion = Convert.ToDateTime(row.fecha_creacion);
                clientes.Add(_cliente);
            }

            return clientes;
        }

        // GET: api/clientes/5
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Getcliente(int id)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcliente(int id, cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.rut)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clienteExists(id))
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

        // POST: api/clientes
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Postcliente(cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cliente.Add(cliente);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (clienteExists(cliente.rut))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cliente.rut }, cliente);
        }

        // DELETE: api/clientes/5
        [ResponseType(typeof(cliente))]
        public IHttpActionResult Deletecliente(int id)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            db.cliente.Remove(cliente);
            db.SaveChanges();

            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clienteExists(int id)
        {
            return db.cliente.Count(e => e.rut == id) > 0;
        }
    }
}