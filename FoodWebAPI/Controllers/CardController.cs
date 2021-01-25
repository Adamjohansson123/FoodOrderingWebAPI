using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FoodWebAPI.Containers.Models;

namespace FoodWebAPI.Controllers
{
    public class CardController : ApiController
    {
        // GET api/values/5
        /// <summary>
        /// See if the customer's card is valid
        /// </summary>
        /// <param name="card">The card that requires validation.</param>
        public Answer Post(Card card)
        {
            return card.IsCardValid();
        }
    }
}
