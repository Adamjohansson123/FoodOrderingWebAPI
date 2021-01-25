using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyFoodAndIngredients : EasyFood
    {
        public string[] NameOfIngredients { get; set; }
    }
}