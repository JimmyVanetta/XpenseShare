using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseShare.Models
{
    public class Currency
    {
        public decimal AmountConvertedFrom { get; set; }

        public decimal ConvertedAmount { get; set; }

        public decimal ExchangeRate { get; set; }

        public string CurrencyCode { get; set; }

        public string CurrencyName { get; set; }
    }
}