using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ExpenseShare.Models
{
    public class BillInfo
    {
        public decimal BillAmount { get; set; } = 0.00m;

        public decimal TipPercent { get; set; }

        public int NumberOfBillShares { get; set; } = 1;

        public int NumberOfTipShares { get; set; }

        public readonly IDictionary<int, decimal> TipPercentages = new Dictionary<int, decimal>
        {
            {5, 0.05m},
            {10, 0.10m},
            {15, 0.15m},
            {20, 0.20m},
            {25, 0.25m},
            {30, 0.30m},
            {35, 0.35m},
            {40, 0.40m},
            {45, 0.45m},
            {50, 0.50m},
            {55, 0.55m},
            {60, 0.60m},
            {65, 0.65m},
            {70, 0.70m},
            {75, 0.75m},
            {80, 0.80m},
            {85, 0.85m},
            {90, 0.90m},
            {95, 0.95m},
            {100, 1.00m},
        };
    }
}