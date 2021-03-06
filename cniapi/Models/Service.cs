﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cniapi.Models
{
    public class Service
    {
        public int SrvcId { get; set; }

        public int? LineId { get; set; }

        public int? CustNum { get; set; }

        public string Status { get; set; }

        public string SrvcClass { get; set; }

        public string SrvcCategory { get; set; }

        public string SrvcRate { get; set; }

        public string SrvcLC { get; set; }

        public string SrvcTax { get; set; }

        public string SrvcType { get; set; }

        public string SrvcDesc { get; set; }

        public DateTime? DepositDate { get; set; }

        public string DepositNum { get; set; }

        public double? DepositAmt { get; set; }
    }
}