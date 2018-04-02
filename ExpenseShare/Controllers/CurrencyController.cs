using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseShare.Models;

namespace ExpenseShare.Controllers
{
    public class CurrencyController : Controller
    {
        // Convert Currency View
        public ActionResult ConvertCurrency()
        {
            CurrencyInfo currencyInfo = new CurrencyInfo();

            ViewBag.Message = "Let's Get to Work!";

            return View("ConvertCurrency", currencyInfo);
        }

        // Convert Currency Result View
        public ActionResult ConvertCurrencyResult(CurrencyInfo currencyInfo)
        {
            Calculator calc = new Calculator();

            Currency currency = new Currency
            {
                AmountConvertedFrom = currencyInfo.AmountToConvert,

                ConvertedAmount = calc.ConvertCurrency(currencyInfo.AmountToConvert, currencyInfo.ExchangeRate)
            };

            ViewBag.Message = "Here Are Your Results";

            return View("ConvertCurrencyResult", currency);
        }
    }
}