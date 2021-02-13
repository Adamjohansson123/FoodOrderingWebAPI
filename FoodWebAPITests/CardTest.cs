using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Testing.Containers
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void Card_Valid_True()
        {
            FoodWebAPI.Models.Card card = new Models.Card();

            card.CardNumber = 1111111111111111;
            card.CVC = 111;
            card.Month = 11;
            card.Year = 11;

            Assert.IsTrue(card.IsCardValid().IsASuccess);
        }
        [TestMethod]
        public void Card_Valid_False()
        {
            FoodWebAPI.Models.Card card = new Models.Card();

            card.CardNumber = 1111111111111;
            card.CVC = 11;
            card.Month = -1;
            card.Year = 111;

            Assert.IsTrue(!card.IsCardValid().IsASuccess);
        }
    }
}