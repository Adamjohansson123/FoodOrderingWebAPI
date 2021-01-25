using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FoodWebAPI.Containers.Models
{
    public class FoodImg : DB.Food
    {
        public string[] ImageHere { get; set; }
        public async Task getImages()
        {
            Task<FlickerAPIClient.Answer> task = FlickerAPIClient.API.GetAll(new string[] {this.Name, "food"});

            List<string> vs = new List<string>();

            FlickerAPIClient.Answer answer = await task;
            if (!answer.IsASuccess)
                this.ImageHere = new string[] { answer.Json.ToString() };

            foreach (string link in (List<string>)answer.Json)
            {
                vs.Add(link);
            }

            this.ImageHere = vs.ToArray();
        }
        public DB.Food Reverse()
        {
            DB.Food outputFood = new DB.Food();

            outputFood.Id = this.Id;
            outputFood.Name = this.Name;
            outputFood.Price = this.Price;
            outputFood.Type = this.Type;
            outputFood.Id_Restaurant = this.Id_Restaurant;

            outputFood.Ingredient_To_Food = this.Ingredient_To_Food;
            outputFood.Order_To_Food = this.Order_To_Food;
            outputFood.Restaurant = this.Restaurant;

            return outputFood;
        }
        public static FoodImg ToFood(DB.Food dbFood)
        {
            FoodImg meFood = new FoodImg();

            meFood.Id = dbFood.Id;
            meFood.Name = dbFood.Name;
            meFood.Price = dbFood.Price;
            meFood.Type = dbFood.Type;
            meFood.Id_Restaurant = dbFood.Id_Restaurant;

            meFood.Ingredient_To_Food = dbFood.Ingredient_To_Food;
            meFood.Order_To_Food = dbFood.Order_To_Food;
            meFood.Restaurant = dbFood.Restaurant;

            return meFood;
        }
        public static List<FoodImg> ToFoodList(List<DB.Food> dbFoods)
        {
            List<FoodImg> meFoods = new List<FoodImg>();

            foreach (DB.Food dbFood in dbFoods)
                meFoods.Add(FoodImg.ToFood(dbFood));

            return meFoods;
        }
        public static async Task<FoodImg> ImagesAndFood(FoodImg food)
        {
            await food.getImages();
            return food;
        }
    }
}