using FoodWebAPI.DB;
using FoodWebAPI.Containers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers
{
    /*
     * The Bonds class are use for controlling relationship between tables
     */
    public static class Bonds
    {
        private static FoodDBEntities db = new FoodDBEntities();
        public static Answer Order_To_Food(int idOrder, int idFood) 
        {
            try
            {
                Order_To_Food to = new Order_To_Food();
                to.Id_Food = idFood;
                to.Id_Order = idOrder;

                db.Order_To_Food.Add(to);
                db.SaveChanges();

                return Answer.Complete("Allt är bra");
            }
            catch (Exception ex)
            {
                return Answer.Error(ex.Message);
            }
        }
        public static Answer Order_To_Drink(int idOrder, int idDrink) 
        {
            try
            {
                Order_To_Drink to = new Order_To_Drink();
                to.Id_Drink = idDrink;
                to.Id_Order = idOrder;

                db.Order_To_Drink.Add(to);
                db.SaveChanges();

                return Answer.Complete("Allt är bra");
            }
            catch (Exception ex)
            {
                return Answer.Error(ex.Message);
            }
        } 
        public static Answer Ingredient_To_Food (int idFood, int idIngredient)
        {
            try
            {
                Ingredient_To_Food to = new Ingredient_To_Food();
                to.Id_Food = idFood;
                to.Id_Ingredient = idIngredient;

                db.Ingredient_To_Food.Add(to);
                db.SaveChanges();

                return Answer.Complete("Allt är bra");
            }
            catch (Exception ex)
            {
                return Answer.Error(ex.Message);
            }
        }
    }
}