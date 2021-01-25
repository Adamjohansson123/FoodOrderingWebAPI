using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodWebAPI.Containers.Models
{

    public class Card
    {
        public long CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int CVC { get; set; }

        public Answer IsCardValid()
        {
            if (!LengthIsRight(CardNumber, 16))
            {
                if (CardNumber.ToString().Length > 16)
                    return Answer.Error("Card Number is to long. It needs to be 16 in length.");
                return Answer.Error("Card Number is to short. It needs to be 16 in length.");

            }
            else if (!LengthIsRight(Month, 2))
            {
                if (Month.ToString().Length > 2)
                    return Answer.Error("Month is to long. It needs to be 2 in length.");
                return Answer.Error("Month is to short. It needs to be 2 in length.");
            }
            else if (!LengthIsRight(Year, 2))
            {
                if (Year.ToString().Length > 2)
                    return Answer.Error("Year is to long. It needs to be 2 in length.");
                return Answer.Error("Year is to short. It needs to be 2 in length.");
            }
            else if (!LengthIsRight(CVC, 3))
            {
                if (CVC.ToString().Length > 3)
                    return Answer.Error("CVC is to long. It needs to be 3 in length.");
                return Answer.Error("CVC is to short. It needs to be 3 in length.");
            }
            else
                return Answer.Complete();
        }
        private static bool LengthIsRight(int input, int max)
        {
            if (input.ToString().Length == max)
                return true;
            return false;
        }
        private static bool LengthIsRight(long input, int max)
        {
            if (input.ToString().Length == max)
                return true;
            return false;
        }

    }
}