﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cniapi.Models
{
    public class History
    {
        public int HistId { get; set; }

        public int CustNum { get; set; }

        public DateTime? PostDate { get; set; }

        public string TranSource { get; set; }

        public string TranDesc { get; set; }

        public int? TranCount { get; set; }

        public double? Amount { get; set; }

        public Boolean? IsBudget { get; set; }

        public double? ResultBalance { get; set; }

        public double? ResultBudget { get; set; }
    }
}