using FoodWebAPI.DB;
using FoodWebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace FoodWebAPITests
{
    [TestClass]
    public class FoodTest
    {
        

        [TestMethod]
        public async void Get_Food()
        {
           
            // Act
            var item = await FoodWebAPI.Containers.FoodBlock.GetFood(3); // Hämtar ett objekt med Id: 3

            // Assert
            Assert.IsTrue(item.Id == 3);
        }

        [TestMethod]
        public async void Get_Food_Error()
        {
            // Act
            var item = await FoodWebAPI.Containers.FoodBlock.GetFood(100); // Försöker hämta ett objekt med Id: 100 vilket inte finns. Detta ska resultera i ett error

            // Assert
            Assert.IsNull(item);
        }

        [TestMethod]
        public async void Get_All_FoodAsync() 
        { 
            var items = await FoodWebAPI.Containers.FoodBlock.GetFood(); // Hämtar en lista med alla Food

            Assert.IsTrue(items.Count() >= 1); // Om det är fler eller lika med 1 så innebär det att det gick att hämta alla objekt
        }

        [TestMethod]
        public async void Put_Food()
        {
            //Arrange 
            Food newFood = new Food(); // Skapar en ny Food
            Food newF = new Food();
            Food newFo = new Food();

            // Act
            newFood.Name = "Pasta Carbonara";
            await FoodWebAPI.Containers.FoodBlock.PostFood(newFood);

            var result = await FoodWebAPI.Containers.FoodBlock.GetFood(); // Hämtar en lista med alla Food

            foreach (var item in result) // Loopar igenom listan och ser om det finns en Food med namnet "Pasta Carbonara"
            {
                if (item.Name == "Pasta Carbonara")
                {
                    newF = item;
                }
            }

            newF.Name = "Spaghetti med köttfärssås";
            await FoodWebAPI.Containers.FoodBlock.PutFood(newF);

            var secondResult = await FoodWebAPI.Containers.FoodBlock.GetFood(); // Hämtar en lista med alla Food igen

            foreach (var item in secondResult) // Loopar igenom listan och ser om det finns en Food med samma Id
            {
                if (item.Id == newF.Id)
                {
                    newFo = item;
                }
            }

            // Assert
            Assert.AreEqual("Spaghetti med köttfärssås", newFo.Name); // Om det finns en Food med samma Id så kollar vi om namnet för det objektet har ändrats
        }

        [TestMethod]
        public async void Delete_Food()
        {
            // Arrange
            Food newFood = new Food(); // Skapar en ny Food
            Food aFood = new Food();
            Food bFood = new Food();

            // Act          
            newFood.Name = "Pizza";
            var newF = FoodWebAPI.Containers.FoodBlock.PostFood(newFood);

            var result = await FoodWebAPI.Containers.FoodBlock.GetFood(); // Hämtar en lista med alla Food

            foreach (var item in result)  // Loopar igenom listan och ser om det finns en Food med namnet Pizza
            {
                if (item.Name == "Pizza")
                {
                    aFood = item;      
                }
            }

            await FoodWebAPI.Containers.FoodBlock.DeleteFood(aFood); // Om objektet hittas så skickas objektets Id till delete funktionen i controllern

            var newResult = await FoodWebAPI.Containers.FoodBlock.GetFood(); // Hämtar en lista med alla Food igen

            foreach (var item in newResult) // Loopar igenom listan och ser om det finns en Food med samma Id som det objektet vi precis skapade
            {
                if (item.Id == aFood.Id)
                {
                    bFood = item;
                }
                else
                {
                    bFood = null;
                }
            }

            // Assert
            Assert.IsNull(bFood); // Om objektet är null så innebär det att det gick att ta bort objektet
        }

        [TestMethod]
        public async void Post_Food()
        {
            // Arrange
            int f_count = 0;

            // Act
            Food newFood = new Food(); // Skapar en ny Food
            newFood.Name = "Pizza";
            await FoodWebAPI.Containers.FoodBlock.PostFood(newFood);

            var result = await FoodWebAPI.Containers.FoodBlock.GetFood(); // Hämtar en lista av alla Food

            foreach (var item in result) // Loopar igenom listan och ser om det finns ett objekt med namnet Pizza. Om det gör det så ökar f_count med 1
            {
                if (item.Name == "Pizza")
                {
                    f_count += 1;
                }
            }

            // Assert
            Assert.IsTrue(f_count > 0); // Om f_count är större än 0 så innebär det att det gick att lägga till objektet

        }
    }
}
