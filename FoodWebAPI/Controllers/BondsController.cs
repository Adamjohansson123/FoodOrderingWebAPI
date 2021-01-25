using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FoodWebAPI.DB;
using FoodWebAPI.Containers.Models;

namespace FoodWebAPI.Controllers
{
    public class BondsController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();
        [Route("bonds/Order_To_Food")]
        public Answer OrToFo(int idOrder, int idFood)
        {
            return Containers.Bonds.Order_To_Food(idOrder, idFood);
        }
        [Route("bonds/Order_To_Drink")]
        public Answer OrToDr(int idOrder, int idDrink)
        {
            return Containers.Bonds.Order_To_Drink(idOrder, idDrink);
        }
        [Route("bonds/Ingredient_To_Food")]
        public Answer InToFo(int idFood, int idIngredient)
        {
            return Containers.Bonds.Ingredient_To_Food(idFood, idIngredient);
        }
    }
}
