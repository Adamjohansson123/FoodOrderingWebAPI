using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DB.Ingredient ToDBIngredient()
        {
            DB.Ingredient ingredient = new DB.Ingredient();

            ingredient.Name = Name;

            return ingredient;
        }
    }
}