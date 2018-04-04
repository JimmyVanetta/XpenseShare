using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseShare.Models
{
    public class Expense
    {
        public decimal BillTotal { get; set; } 

        public decimal BillResult { get; set; }

        public decimal TipResult { get; set; }

        public decimal SharedTip { get; set; }

        public decimal BillPlusTip { get; set; }

        public decimal IndividualBillPlusIndividualTip { get; set; }

        public int NumberSharingBill { get; set; }

        public int NumberSharingTip { get; set; }
    }
}