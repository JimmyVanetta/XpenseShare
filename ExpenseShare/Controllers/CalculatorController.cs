using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseShare.Models;

namespace ExpenseShare.Controllers
{
    public class CalculatorController : Controller
    {
        // Bill Calculator View
        public ActionResult BillCalculator()
        {
            BillInfo billInfo = new BillInfo();

            ViewBag.Message = "Let's Get to Work!";

            return View("BillCalculator", billInfo);
        }

        // Tip Calculator View
        public ActionResult TipCalculator()
        {
            BillInfo billInfo = new BillInfo();

            ViewBag.Message = "Let's Get to Work!";

            return View("TipCalculator", billInfo);
        }

        // Results View
        public ActionResult CalculatorResult(BillInfo billInfo /* Passing along the model built in Bill Calculator or Tip Calculator */)
        {
            // Instance of Calculator to be used 
            Calculator calc = new Calculator();

            // Instance of Expense to be passed through as the model
            Expense bill = new Expense
            {
                // Set the Bill Result to be displayed 
                BillResult = calc.DivideBill(billInfo.BillAmount, billInfo.NumberOfBillShares),

                // Set the Tip Result to be displayed
                TipResult = calc.CalculatePercentage(billInfo.BillAmount, billInfo.TipPercent),

                // Set the amount of people sharing the bill 
                NumberSharingBill = billInfo.NumberOfBillShares,

                // Set the amount of people sharing the tip
                NumberSharingTip = billInfo.NumberOfTipShares
            };

            ViewBag.Message = "Here Are Your Results";

            return View("CalculatorResult", bill);
        }
    }
}