using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpenseShare.Models;
using ExpenseShare.Controllers;

namespace ExpenseShareTests
{
    [TestClass]
    public class CalculatorTests
    {
        CurrencyController currencyControl = new CurrencyController();
        Calculator calc = new Calculator();

        [TestMethod]
        public void DivideBillTest_ReturnTrue()
        {
            decimal output1 = calc.DivideBill(100.00m, 4);
            decimal output2 = calc.DivideBill(75.00m, 3);
            decimal output3 = calc.DivideBill(247.52m, 7);

            Assert.AreEqual(25.00m, output1);
            Assert.AreEqual(25.00m, output2);
            Assert.AreEqual(35.36m, output3);
        }

        [TestMethod]
        public void CalculatePercentageTest_ReturnTrue()
        {
            decimal output1 = calc.CalculatePercentage(100.00m, 0.25m);
            decimal output2 = calc.CalculatePercentage(35.36m, 0.35m);
            decimal output3 = calc.CalculatePercentage(247.52m, 0.15m);

            Assert.AreEqual(25.00m, output1);
            Assert.AreEqual(12.38m, output2);
            Assert.AreEqual(37.13m, output3);
        }
    }
}
