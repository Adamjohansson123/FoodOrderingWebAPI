using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWebAPITests.Containers
{
    [TestClass]
    public class FoodsTest
    {
        public static FoodWebAPI.Models.FoodImg newTestFood = new FoodWebAPI.Models.FoodImg();

        //Hitta alla
        [TestMethod]
        public void Get_All()
        {
            List<FoodWebAPI.Models.FoodImg> foods = new List<FoodWebAPI.Models.FoodImg>();

            Task<List<FoodWebAPI.Models.FoodImg>> result = FoodWebAPI.Containers.Foods.GetAll();
            result.Wait();

            foods = result.Result;

            Assert.IsTrue(foods.Count >= 1);
        }
        //Lägg till ny
        [TestMethod]
        public void Add_Food()
        {
            FoodWebAPI.Models.FoodImg outputFoodImg = new FoodWebAPI.Models.FoodImg();
            FoodWebAPI.Models.EasyInputs.EasyFood inputFood = new FoodWebAPI.Models.EasyInputs.EasyFood();

            inputFood.Id_Restaurant = 4;
            inputFood.Name = "Test food: " + DateTime.Now.ToString();
            inputFood.Price = 10;
            inputFood.Type = "Test Food";

            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.Add(inputFood);
            result.Wait();

            outputFoodImg = result.Result;
            newTestFood = outputFoodImg;

            Assert.IsTrue(inputFood.Name == outputFoodImg.Name);
        }
        //Hitta den nya
        [TestMethod]
        public void Get_One()
        {
            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.GetOne(newTestFood.Id);
            result.Wait();

            FoodWebAPI.Models.FoodImg foodImg = result.Result;

            Assert.AreSame(foodImg, newTestFood);
        }
        //Ta bort den nya
        [TestMethod]
        public void Remove()
        {
            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.Remove(FoodWebAPI.Models.FoodImg.ToFood(newTestFood));
            result.Wait();

            FoodWebAPI.Models.FoodImg foodImg = result.Result;

            Assert.AreSame(foodImg, newTestFood);
        }
        //Se om ny är borta
        [TestMethod]
        public void Get_One_Error()
        {
            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.GetOne(newTestFood.Id);
            result.Wait();

            FoodWebAPI.Models.FoodImg foodImg = result.Result;

            Assert.AreNotSame(foodImg, newTestFood);
        }
    }
}
