using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseShare.Models
{
    public class Calculator
    {
        public decimal DivideBill(decimal bill, int split)
        {
            decimal result;

            if (split.Equals(0))
            {
                result = bill; 
            }
            else
            {
                result = Math.Round((bill / split), 2);
            }

            return result;
        }

        public decimal CalculatePercentage(decimal bill, decimal percent)
        {
            decimal result;

            if (percent == 0.00m)
            {
                result = percent;
            }
            else
            {
                result = Math.Round((bill * percent), 2);
            }

            return result;
        }

        public decimal ConvertCurrency(decimal amountToConvert, decimal exchangeRate)
        {
            decimal result = Math.Round((amountToConvert) * (exchangeRate), 2);

            return result;
        }
    }
}