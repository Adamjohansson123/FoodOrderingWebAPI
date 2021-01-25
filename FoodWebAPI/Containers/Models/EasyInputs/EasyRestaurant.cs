using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace FoodWebAPI.Containers.Models.EasyInputs
{
    public class EasyRestaurant
    {
        public string Name { get; set; }
        public int Popularity { get; set; }
        public int Id_City { get; set; }
        public string Adress { get; set; }
        public string TypeOfFood { get; set; }
        public string Img { get; set; }

        public Answer Controllers()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
                return Answer.Error("Name can not be null, Empty or white space.");

            if (string.IsNullOrEmpty(Adress) || string.IsNullOrWhiteSpace(Adress))
                return Answer.Error("Adress can not be null, Empty or white space.");

            if (Popularity >= 6  || Popularity <= -1)
                return Answer.Error("Popularity can not be under 0 or higher than 5(0-5)");

            if (Img.Length > 256000)
                return Answer.Error("Img size can not be bigger then 256 kilobytes.(256 000 bytes)");

            if (Id_City >= -1)
                return Answer.Error("Id_City can to be or be under -1.");

            return Answer.Complete();
        }
        public DB.Restaurant ToDBRestaurant()
        {
            DB.Restaurant restaurant = new DB.Restaurant();
            restaurant.Adress = Adress;
            restaurant.Id_City = Id_City;
            restaurant.Img = Img;
            restaurant.Name = Name;
            restaurant.Popularity = Popularity;
            restaurant.TypeOfFood = TypeOfFood;

            return restaurant;
        }
    }
}