using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cniapi.Models
{
    public class ServiceUsage
    {
        public string ServiceType { get; set; }
        public int Count { get; set; }
        public double? DepositAmount { get; set; }
    }
}