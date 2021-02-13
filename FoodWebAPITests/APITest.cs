using FlickerAPIClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FoodWebAPITests
{
    [TestClass]
    public class APITest
    {
       [TestMethod]
        public void Fetch_more_than_50()
        {
            Task<List<string>> task = GetAllImagesAsync(new string[] { "Hamburger" });
            task.Wait();
            List<string> imgs = task.Result;

            Assert.IsTrue(imgs.Count >= 50);
        }
        [TestMethod]
        public void More_inputs_fetch_more_than_50()
        {
            Task<List<string>> task = GetAllImagesAsync(new string[] { "Hamburger", "pizza", "food" });
            task.Wait();
            List<string> imgs = task.Result;

            Assert.IsTrue(imgs.Count >= 50);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values in input string[] can not be empty or null.")]
        public void Poor_input()
        {
            Task<List<string>> task = GetAllImagesAsync(new string[] { "", string.Empty });
            task.Wait();
            //List<string> imgs = task.Result;

            //Assert.IsTrue(imgs.Count > 0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Input string[] can not be empty.")]
        public void No_input()
        {
            Task<List<string>> task = GetAllImagesAsync(new string[] {});
            task.Wait();
            //List<string> imgs = task.Result;

            //Assert.IsTrue(imgs.Count > 0);
        }

        private async Task<List<string>> GetAllImagesAsync(string[] input)
        {
            Answer AllImages = await API.GetAll(input);
            List<string> AllImg = (List<string>) AllImages.Json;

            return AllImg;
        }
    }
}
