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
using FoodWebAPI.Containers.Models.EasyInputs;

namespace FoodWebAPI.Controllers
{
    public class CitiesController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: /Cities
        /// <summary>
        /// See if the customer's card is valid
        /// </summary>
        public IQueryable<City> GetCity()
        {
            return db.City;
        }

        // GET: /Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> GetCity(int id)
        {
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCity(int id, EasyCity city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            DB.City cityDb = city.ToDBCity();
            cityDb.Id = id;

            db.Entry(cityDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: /Cities
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> PostCity([FromBody] EasyCity city)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.City.Add(city.ToDBCity());
            await db.SaveChangesAsync();

            DB.City cityDb = db.City.Where(n => n.Name == city.Name).FirstOrDefault();

            return CreatedAtRoute("DefaultApi", new { id = cityDb.Id }, cityDb);
        }

        // DELETE: /Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> DeleteCity(int id)
        {
            City city = await db.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            db.City.Remove(city);
            await db.SaveChangesAsync();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(int id)
        {
            return db.City.Count(e => e.Id == id) > 0;
        }
    }
}