using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseShare.Models
{
    public class CurrencyInfo
    {
        public decimal AmountToConvert { get; set; }

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }

        public IList<string> ExchangeRates { get; set; }
    }
}