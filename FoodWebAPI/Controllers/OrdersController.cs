using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FoodWebAPI.DB;

namespace FoodWebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: /Orders
        public IQueryable<Order> GetOrder()
        {
            return db.Order;
        }

        // GET: /Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: /Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Containers.Models.EasyInputs.EasyOrder order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            DB.Order orderDb = order.ToDBOrder();
            orderDb.Id = id;

            db.Entry(orderDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: /Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Containers.Models.EasyInputs.EasyOrder order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DB.Order outputOrder = new DB.Order();

            outputOrder = order.ToDBOrder();

            db.Order.Add(order.ToDBOrder());
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = outputOrder.Id }, outputOrder);
        }

        // DELETE: /Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Order.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Order.Count(e => e.Id == id) > 0;
        }
    }
}