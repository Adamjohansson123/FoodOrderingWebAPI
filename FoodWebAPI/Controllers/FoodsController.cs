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
using FoodWebAPI.Containers.Models;
using FoodWebAPI.Containers.Models.EasyInputs;

namespace FoodWebAPI.Controllers
{
    public class FoodsController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: /Foods
        [ResponseType(typeof(List<FoodImg>))]
        public async Task<IHttpActionResult> GetFood()
        {
            List<FoodImg> mFoods = await Containers.Foods.GetAll();
            return Ok(mFoods);
        }

        // GET: /Foods/5
        [ResponseType(typeof(FoodImg))]
        public async Task<IHttpActionResult> GetFood(int id)
        {
            FoodImg food = await Containers.Foods.GetOne(id);

            if (food == null)
                return NotFound();

            await food.getImages();
            return Ok(FoodImg.ToFood(food));
        }

        // PUT: /Foods/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFood(int id, Containers.Models.EasyInputs.EasyFood food)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DB.Food foodDb = food.ToDBFood();
            foodDb.Id = id;

            db.Entry(foodDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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

        // POST: /Foods
        [ResponseType(typeof(FoodImg))]
        public async Task<IHttpActionResult> PostFood(Containers.Models.EasyInputs.EasyFood food)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            FoodImg imgFoodOutput = await Containers.Foods.Add(food);

            return CreatedAtRoute("DefaultApi", new { id = imgFoodOutput.Id }, imgFoodOutput);
        }

        

        // DELETE: /Foods/5
        [ResponseType(typeof(FoodImg))]
        public async Task<IHttpActionResult> DeleteFood(int id)
        {
            //Hitta och ta bort
            Food food = await db.Food.FindAsync(id);
            if (food == null)
                return NotFound();

            FoodImg foodImg = new FoodImg();
            foodImg = await Containers.Foods.Remove(food);

            return Ok(FoodImg.ToFood(foodImg));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodExists(int id)
        {
            return db.Food.Count(e => e.Id == id) > 0;
        }
    }
}