using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyCity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DB.City ToDBCity()
        {
            DB.City city = new DB.City();

            city.Name = Name;

            return city;
        }

    }
}