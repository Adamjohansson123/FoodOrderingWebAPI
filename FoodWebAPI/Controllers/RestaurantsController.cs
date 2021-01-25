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
    public class RestaurantsController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: /Restaurants/
        public IQueryable<Restaurant> GetRestaurant()
        {
            return db.Restaurant;
        }

        // GET: /Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> GetRestaurant(int id)
        {
            Restaurant restaurant = await db.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }
       
        // PUT: /Restaurants/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurant(int id, Containers.Models.EasyInputs.EasyRestaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            DB.Restaurant restaurantDB = restaurant.ToDBRestaurant();
            restaurantDB.Id = id;

            db.Entry(restaurantDB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: /Restaurants/
        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> PostRestaurant(Containers.Models.EasyInputs.EasyRestaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           

            db.Restaurant.Add(restaurant.ToDBRestaurant());
            await db.SaveChangesAsync();

            DB.Restaurant restaurantDb = db.Restaurant
                .Where(a => a.Adress == restaurant.Adress)
                .Where(i => i.Id_City == restaurant.Id_City)
                .Where(i => i.Img.Length == restaurant.Img.Length)
                .Where(n => n.Name == restaurant.Name)
                .Where(p => p.Popularity == restaurant.Popularity)
                .Where(t => t.TypeOfFood == restaurant.TypeOfFood)
                .FirstOrDefault();

            return CreatedAtRoute("DefaultApi", new { Name = restaurantDb.Id }, restaurantDb);
        }

        // DELETE: /Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public async Task<IHttpActionResult> DeleteRestaurant(int id)
        {
            Restaurant restaurant = await db.Restaurant.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            db.Restaurant.Remove(restaurant);
            await db.SaveChangesAsync();

            return Ok(restaurant);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestaurantExists(int id)
        {
            return db.Restaurant.Count(e => e.Id == id) > 0;
        }
    }
}