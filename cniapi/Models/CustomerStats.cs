using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cniapi.Models
{
    public class CustomerStats
    {
        public int Total { get; set; }
        public int Active { get; set; }
        public int WithEmail { get; set; }
        public int WithBudgetPayments { get; set; }
        public int WithBankDraft { get; set; }
        public int PaidInFull { get; set; }
        public int PastDue { get; set; }
        public int CurrentDue { get; set; }
        public double TotalPastDue { get; set; }
        public double AveragePastDue { get; set; }

        public int ErrorPayments { get; set; }
    }
}