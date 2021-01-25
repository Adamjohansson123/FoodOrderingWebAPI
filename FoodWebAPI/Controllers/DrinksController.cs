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
    public class DrinksController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: /Drinks
        public IQueryable<Drink> GetDrink()
        {
            return db.Drink;
        }

        // GET: /Drinks/5
        [ResponseType(typeof(Drink))]
        public async Task<IHttpActionResult> GetDrink(int id)
        {
            Drink drink = await db.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }

        // PUT: /Drinks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDrink(int id, Containers.Models.EasyInputs.EasyDrink drink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DB.Drink drinkDb = drink.ToDNDrink();
            drinkDb.Id = id;

            db.Entry(drinkDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinkExists(id))
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

        // POST: /Drinks
        [ResponseType(typeof(Drink))]
        public async Task<IHttpActionResult> PostDrink(Containers.Models.EasyInputs.EasyDrink drink)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Drink.Add(drink.ToDNDrink());
            await db.SaveChangesAsync();

            DB.Drink drinkDb = db.Drink.Where(n => n.Name == drink.Name).FirstOrDefault();

            return CreatedAtRoute("DefaultApi", new { id = drinkDb.Id }, drinkDb);
        }

        // DELETE: /Drinks/5
        [ResponseType(typeof(Drink))]
        public async Task<IHttpActionResult> DeleteDrink(int id)
        {
            Drink drink = await db.Drink.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }

            db.Drink.Remove(drink);
            await db.SaveChangesAsync();

            return Ok(drink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrinkExists(int id)
        {
            return db.Drink.Count(e => e.Id == id) > 0;
        }
    }
}