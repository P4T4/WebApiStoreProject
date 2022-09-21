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
using ApiRestStoreProject.Models;

namespace ApiRestStoreProject.Controllers
{
    public class ventasController : ApiController
    {
        private ModelStore db = new ModelStore();

        // GET: api/ventas
        public IQueryable<venta> GetventaFilterClient(int id_cliente)
        {
            return db.venta.Where(v => v.id_cliente == id_cliente);
        }

        // GET: api/ventas/5
        [ResponseType(typeof(venta))]
        public IHttpActionResult Getventa(int id)
        {
            venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        // PUT: api/ventas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putventa(int id, venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.id_venta)
            {
                return BadRequest();
            }

            db.Entry(venta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ventaExists(id))
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

        // POST: api/ventas
        [ResponseType(typeof(venta))]
        public IHttpActionResult Postventa(venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.venta.Add(venta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = venta.id_venta }, venta);
        }

        // DELETE: api/ventas/5
        [ResponseType(typeof(venta))]
        public IHttpActionResult Deleteventa(int id)
        {
            venta venta = db.venta.Find(id);
            if (venta == null)
            {
                return NotFound();
            }

            db.venta.Remove(venta);
            db.SaveChanges();

            return Ok(venta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ventaExists(int id)
        {
            return db.venta.Count(e => e.id_venta == id) > 0;
        }
    }
}