using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseShare.Models;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace ExpenseShare.Controllers
{
    public class CurrencyController : Controller
    {

        // Convert Currency View
        public async Task<ActionResult> ConvertCurrency()
        {
            CurrencyInfo currencyInfo = new CurrencyInfo();

            var exchangeRateResponse = await GetCurrentExchangeRates();
            //var currencyNameResponse = await GetCurrentCurrencyNames();

            ViewBag.Message = "Let's Get to Work!";

            return View("ConvertCurrency", currencyInfo);
        }
        
        // Convert Currency Result View
        [HttpPost]
        public async Task<ActionResult> ConvertCurrencyResult(CurrencyInfo currencyInfo)
        {
            Calculator calc = new Calculator();

            var exchangeRateResponse = await GetCurrentExchangeRates();
            var currencyNameResponse = await GetCurrentCurrencyNames();
            
            currencyInfo.ExchangeRate = GetExchangeRateForCountry(currencyInfo.CurrencyCode, exchangeRateResponse.Quotes);

            Currency currency = new Currency
            {
                AmountConvertedFrom = currencyInfo.AmountToConvert,

                ConvertedAmount = calc.ConvertCurrency(currencyInfo.AmountToConvert, currencyInfo.ExchangeRate),

                CurrencyName = GetCurrencyNamesFromCurrencyCode(currencyInfo.CurrencyCode.Remove(0, 3), currencyNameResponse.Currencies),

                CurrencyCode = currencyInfo.CurrencyCode.Remove(0, 3),

                ExchangeRate = currencyInfo.ExchangeRate
            };

            ViewBag.Message = "Here Are Your Results";

            return View("ConvertCurrencyResult", currency);
        }

        private IList<string> GetCurrencyOptions()
        {
            var type = typeof(Quotes);

            var properties = type.GetProperties().ToList();

            var codes = properties.Select(p => p.Name);

            return codes.ToList();
        }

        //private IList<string> GetCurrencyNames()
        //{
        //    var type = typeof(Currencies);

        //    var properties = type.GetProperties().ToList();

        //    var names = properties.Select(p => p.Name);

        //    return names.ToList();
        //}
        [HttpGet]
        private string GetCurrencyNamesFromCurrencyCode(string currencyCode, Currencies currencies)
        {
            string name = "";
            var type = typeof(Currencies);
            var property = type.GetProperty(currencyCode);

            if (property != null)
            {
                name = (string)property.GetValue(currencies);
            }

            return name;
        }

        private decimal GetExchangeRateForCountry(string currencyCode, Quotes availableRates)
        {
            decimal rate = 0.00m;
            var type = typeof(Quotes);
            var property = type.GetProperty(currencyCode.ToUpper());

            if (property != null)
            {
                rate = (decimal)property.GetValue(availableRates);
            }
            
            return rate;
        }

        private async Task<ExchangeRateResponse> GetCurrentExchangeRates()
        {           
            // Exchange Rate Endpoint
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("http://www.apilayer.net/api/live?access_key=802e2a672e4f08d872ab189ce4c2fc6c");

                var exchangeRates = JsonConvert.DeserializeObject<ExchangeRateResponse>(response);

                return exchangeRates;
            }            
        }

        // Currency Name Endpoint
        private async Task<CurrencyNameResponse> GetCurrentCurrencyNames()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("http://apilayer.net/api/list?access_key=802e2a672e4f08d872ab189ce4c2fc6c");

                var currencyNames = JsonConvert.DeserializeObject<CurrencyNameResponse>(response);

                return currencyNames;
            }
        }
    }
}