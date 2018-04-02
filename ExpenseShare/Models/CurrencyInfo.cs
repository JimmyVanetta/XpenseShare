using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseShare.Models
{
    public class CurrencyInfo
    {
        public decimal AmountToConvert { get; set; }

        public decimal ExchangeRate { get; set; }

        // TODO: 
        // Add a collection of exchange rates, populate the collection with json through fixer.io API
        // Add a helper method GetExchangeRate 
    }
}