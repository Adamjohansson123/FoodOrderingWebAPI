using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWebAPI.Testing.Containers
{
    [TestClass]
    public class BondsTest
    {
        [TestMethod]
        public void Order_To_Food_Add()
        {
            int idOrder = 0
                , idFood = 0;

            FoodWebAPI.Models.Answer answer = FoodWebAPI.Containers.Bonds.Order_To_Food(idOrder, idFood);
        }
        [TestMethod]
        public void Order_To_Drink_Add()
        {
            int idOrder = 0
                , idDrink = 0;

            FoodWebAPI.Models.Answer answer = FoodWebAPI.Containers.Bonds.Order_To_Drink(idOrder, idDrink);
        }
        [TestMethod]
        public void Ingredient_To_Food_Add()
        {
            int idIngredient = 0
                , idFood = 0;

            FoodWebAPI.Models.Answer answer = FoodWebAPI.Containers.Bonds.Ingredient_To_Food(idIngredient, idFood);
        }
    }
}