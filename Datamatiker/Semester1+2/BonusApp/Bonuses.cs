using System;
using System.Collections.Generic;
using System.Text;

namespace BonusApp
{
    public class Bonuses
    {
        public static double TenPercent(double amount)
        {
            return amount * 0.1;
        }
        public static double FlatTwoIfAmountMoreThanFive(double amount)
        {
            if (amount > 5)
                return 2.0;

            else
                return 0;
        }
    }
}
