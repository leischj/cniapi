﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cniapi.Models
{
    public class PmtEntry
    {
        public int PmtEntryId { get; set; }

        public int CustNum { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? ExportDate { get; set; }

        public int? Status { get; set; }

        public string PmtType { get; set; }

        public double? PmtAmount { get; set; }

        public double? PmtFee { get; set; }

        public string Reference { get; set; }

        public string Processor { get; set; }

        // TODO: Lots of other fields but we'll use these for now...
    }
}