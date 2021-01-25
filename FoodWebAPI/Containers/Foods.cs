using FoodWebAPI.DB;
using FoodWebAPI.Containers.Models;
using FoodWebAPI.Containers.Models.EasyInputs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FoodWebAPI.Containers
{
    /*
     * The Foods class contain the functionality that's needed for controlling the Foods table
     */
    public static class Foods
    {
        #region Props
        private static DB.FoodDBEntities db = new FoodDBEntities();
        #endregion

        #region Public
        #region Get
        public static async Task<List<FoodImg>> GetAll()
        {
            IQueryable<Food> foods = db.Food;
            List<FoodImg> mFoods = FoodImg.ToFoodList(foods.ToList());
            List<Task> tasks = new List<Task>();

            //Hittar alla bilder
            for (int i = 0; i < mFoods.Count; i++)
            {
                Task task = mFoods[i].getImages();
                tasks.Add(task);
            }

            //Väntar på det...

            for (int i = 0; i < tasks.Count; i++)
            {
                await tasks[i];
            }

            return mFoods;
        }
        public static async Task<FoodImg> GetOne(int id)
        {
            return FoodImg.ToFood(await db.Food.FindAsync(id));
        }
        #endregion
        #region Add
        public static async Task<FoodImg> Add(EasyFood food)
        {
            try
            {
                DB.Food foodDb = await FindFoodByNoId(food.ToDBFood());
                FoodImg imgFoodOutput = new FoodImg();

                if (foodDb is null || foodDb.Id < 0)
                {
                    Food inputDbFood = food.ToDBFood();
                    db.Food.Add(inputDbFood);
                    await db.SaveChangesAsync();

                    foodDb = await FindFoodByNoId(food.ToDBFood());

                    imgFoodOutput = FoodImg.ToFood(foodDb);
                    await imgFoodOutput.getImages();
                }
                else
                {
                    imgFoodOutput = FoodImg.ToFood(foodDb);
                    await imgFoodOutput.getImages();
                }

                return imgFoodOutput;

            }
            catch (Exception)
            {
                return new FoodImg();
            }
        }
        #endregion
        #region Remove
        public static async Task<FoodImg> Remove(DB.Food inputFood)
        {
            try
            {
                Food outputFood = new Food();
                outputFood = inputFood;

                db.Food.Remove(outputFood);
                await db.SaveChangesAsync();

                //Något att ge tillbacka

                FoodImg imgFood = new FoodImg();

                imgFood = FoodImg.ToFood(outputFood);
                await imgFood.getImages();

                return imgFood;
            }
            catch (Exception)
            {
                return new FoodImg();
            }
        }
        #endregion
        #endregion
        #region Private
        private static async Task<DB.Food> FindFoodByNoId(DB.Food inputFood)
        {
            DB.Food outputFood = await db.Food
                .Where(n => n.Name == inputFood.Name)
                .Where(p => p.Price == inputFood.Price)
                .Where(t => t.Type == inputFood.Type)
                .Where(i => i.Id_Restaurant == inputFood.Id_Restaurant)
                .FirstOrDefaultAsync();
            return outputFood;
        }
        #endregion
    }
}