using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseShare.Models;
using ExpenseShare.DAL;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ExpenseShare.Controllers
{
    public class CurrencyController : Controller
    {
        private ExchangeRateDAL currencyDAL = new ExchangeRateDAL();

        // Convert Currency View
        public async Task<ActionResult> ConvertCurrency()
        {
            CurrencyInfo currencyInfo = new CurrencyInfo();

            var currencies = GetCurrencyOptions();

            ViewBag.Message = "Let's Get to Work!";

            return View("ConvertCurrency", currencyInfo);
        }
        
        // Convert Currency Result View
        public async Task<ActionResult> ConvertCurrencyResult(CurrencyInfo currencyInfo)
        {
            Calculator calc = new Calculator();

            var exchangeRateResponse = await GetCurrentExchangeRates();

            var rateForAUD = GetExchangeRateForCountry("AUD", exchangeRateResponse.Rates);

            Currency currency = new Currency
            {
                AmountConvertedFrom = currencyInfo.AmountToConvert,

                ConvertedAmount = calc.ConvertCurrency(currencyInfo.AmountToConvert, currencyInfo.ExchangeRate)
            };

            ViewBag.Message = "Here Are Your Results";

            return View("ConvertCurrencyResult", currency);
        }

        private IList<string> GetCurrencyOptions()
        {
            var type = typeof(Rates);
            var properties = type.GetProperties().ToList();

            var names = properties.Select(p => p.Name);
            return names.ToList();
        }


        private decimal GetExchangeRateForCountry(string currencyCode, Rates availableRates)
        {
            decimal rate = 0.00m;
            var type = typeof(Rates);
            var property = type.GetProperty(currencyCode.ToUpper());

            if (property != null)
            {
                rate = (decimal)property.GetValue(availableRates);
            }
            
            return rate;
        }

        private async Task<ExchangeRateResponse> GetCurrentExchangeRates()
        {            
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("http://data.fixer.io/api/latest?access_key=7f9a7ad37ef6c568c4090c22ee6cb7e2");

                var exchangeRates = JsonConvert.DeserializeObject<ExchangeRateResponse>(response);

                return exchangeRates;
            }            
        }
    }
}