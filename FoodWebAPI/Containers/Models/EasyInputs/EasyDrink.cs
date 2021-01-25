using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyDrink
    {
        public String Name { get; set; }
        public int Price { get; set; }

        public DB.Drink ToDNDrink()
        {
            DB.Drink drink = new DB.Drink();

            drink.Name = Name;
            drink.Price = Price;

            return drink;
        }
    }
}