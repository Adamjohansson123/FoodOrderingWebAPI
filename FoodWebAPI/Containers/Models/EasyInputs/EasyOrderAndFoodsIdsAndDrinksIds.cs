using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyOrderAndFoodsIdsAndDrinksIds : EasyOrder
    {
        public List<int> Foods_Ids { get; set; }
        public List<int> Drinks_Ids { get; set; }

        public EasyOrder ToEasyOrder()
        {
            EasyOrder order = new EasyOrder();

            order.CustomerAdress = this.CustomerAdress;
            order.CustomerEmail = this.CustomerEmail;
            order.CustomerFirstName = this.CustomerFirstName;
            order.CustomerLastName = this.CustomerLastName;
            order.CustomerPhoneNumber = this.CustomerPhoneNumber;
            order.CustomerZIP = this.CustomerZIP;
            order.Id_City = this.Id_City;

            return order;
        }
    }
}