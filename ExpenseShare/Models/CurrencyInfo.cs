using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseShare.Models
{
    public class CurrencyInfo
    {
        public decimal AmountToConvert { get; set; } = 0.00m;

        public string CurrencyCode { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}