using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyOrder
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerZIP { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int Id_City { get; set; }
        public DB.Order ToDBOrder()
        {
            DB.Order order = new DB.Order();

            order.CustomerFirstName = CustomerFirstName;
            order.CustomerLastName = CustomerLastName;
            order.CustomerAdress = CustomerAdress;
            order.CustomerZIP = CustomerZIP;
            order.CustomerEmail = CustomerEmail;
            order.CustomerPhoneNumber = CustomerPhoneNumber;
            order.Id_City = Id_City;

            return order;
        }

    }
}