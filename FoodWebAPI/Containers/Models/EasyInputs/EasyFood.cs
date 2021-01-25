using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyFood
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int Id_Restaurant { get; set; }
        public DB.Food ToDBFood()
        {
            DB.Food food = new DB.Food();

            food.Name = Name;
            food.Type = Type;
            food.Price = Price;
            food.Id_Restaurant = Id_Restaurant;
            food.Id = 0;

            return food;
        }
    }
}