using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWebAPI.Testing.Containers
{
    [TestClass]
    public class FoodsTest
    {
        public static FoodWebAPI.Models.FoodImg newTestFood = new FoodWebAPI.Models.FoodImg();

        private TestContext testContextInstance;

        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        [TestMethod]
        public void Test_List_Food()
        {
            Get_All();
            Add_Food();
            Get_One();
            //Remove();
            Get_One_Error();
        }

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
            FoodWebAPI.Models.EasyInputs.EasyFood inputFood = new FoodWebAPI.Models.EasyInputs.EasyFood();

            inputFood.Id_Restaurant = 41;
            inputFood.Name = "Test food: " + DateTime.Now.ToString();
            inputFood.Price = 10;
            inputFood.Type = "Test Food";


            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.Add(inputFood);
            result.Wait();

            newTestFood = result.Result;

            //TestContext.WriteLine("");

            Assert.IsNotNull(new FoodWebAPI.Models.FoodImg().Name == newTestFood.Name);
        }
        //Hitta den nya
        [TestMethod]
        public void Get_One()
        {
            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.GetOne(newTestFood.Id);
            result.Wait();

            FoodWebAPI.Models.FoodImg foodImg = result.Result;



            Assert.IsTrue(foodImg.Id == newTestFood.Id);
        }
        //Ta bort den nya
        [TestMethod]
        public void Remove()
        {
            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.Remove(FoodWebAPI.Models.FoodImg.ToFood(newTestFood));
            result.Wait();

            FoodWebAPI.Models.FoodImg foodImg = result.Result;

            TestContext.WriteLine("removed item: " + foodImg.Id.ToString());
            TestContext.WriteLine("\t" + "ID: " + foodImg.Id.ToString());
            TestContext.WriteLine("\t" + "Name: " + foodImg.Name.ToString());

            TestContext.WriteLine("old item: " + newTestFood.Id.ToString());
            TestContext.WriteLine("\t" + "ID: " + newTestFood.Id.ToString());
            TestContext.WriteLine("\t" + "Name: " + newTestFood.Name.ToString());

            Assert.IsTrue(foodImg.Id == newTestFood.Id);
        }
        //Se om ny är borta
        [TestMethod]
        public void Get_One_Error()
        {
            Task<FoodWebAPI.Models.FoodImg> result = FoodWebAPI.Containers.Foods.GetOne(newTestFood.Id);
            result.Wait();

            FoodWebAPI.Models.FoodImg foodImg = result.Result;

            Assert.IsTrue(!(foodImg.Id == newTestFood.Id));
        }
    }
}