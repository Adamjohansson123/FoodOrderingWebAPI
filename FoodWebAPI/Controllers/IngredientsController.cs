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
    public class IngredientsController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: /Ingredients
        public IQueryable<Ingredient> GetIngredient()
        {
            return db.Ingredient;
        }

        // GET: /Ingredients/5
        [ResponseType(typeof(Ingredient))]
        public async Task<IHttpActionResult> GetIngredient(int id)
        {
            Ingredient ingredient = await db.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // PUT: /Ingredients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutIngredient(int id, Containers.Models.EasyInputs.EasyIngredient ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DB.Ingredient ingredientDb = ingredient.ToDBIngredient();
            ingredientDb.Id = id;

            db.Entry(ingredientDb).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
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

        // POST: /Ingredients
        [ResponseType(typeof(Ingredient))]
        public async Task<IHttpActionResult> PostIngredient(Containers.Models.EasyInputs.EasyIngredient ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            

            db.Ingredient.Add(ingredient.ToDBIngredient());
            await db.SaveChangesAsync();

            DB.Ingredient ingredientDb = db.Ingredient.Where(n => n.Name == ingredient.Name).FirstOrDefault();


            return CreatedAtRoute("DefaultApi", new { id = ingredientDb.Id }, ingredientDb);
        }

        // DELETE: /Ingredients/5
        [ResponseType(typeof(Ingredient))]
        public async Task<IHttpActionResult> DeleteIngredient(int id)
        {
            Ingredient ingredient = await db.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            db.Ingredient.Remove(ingredient);
            await db.SaveChangesAsync();

            return Ok(ingredient);
        }
        /*
        // POST: /Ingredients/
        [ResponseType(typeof(List<Ingredient>))]
        public async Task<IHttpActionResult> PostIngredients(List<Ingredient> ingredients)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (ingredients.Count <= 0)
                return Ok(ingredients);

            foreach (Ingredient ingredient in ingredients)
                db.Ingredient.Add(ingredient);

            await db.SaveChangesAsync();

            return Ok(ingredients);
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredientExists(int id)
        {
            return db.Ingredient.Count(e => e.Id == id) > 0;
        }
    }
}