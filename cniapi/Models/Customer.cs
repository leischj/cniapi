using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cniapi.Models
{
    public class Customer
    {
        public int CustNum { get; set; }
        public int? Route { get; set; }
        public int? Account { get; set; }
        public int? Sub { get; set; }
        public int? Cycle { get; set; }
        public string Status { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string DriverLicense { get; set; }
        public string SocSecNum { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2  { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public string BillZip { get; set; }
        public string ServiceAddress { get; set; }
        public string PaymentComment { get; set; }
        public float? PastDue { get; set; }
        public float? CurrentDue { get; set; }
        public float? TotalDue { get; set; }
        public float? BudgetPymtAmt { get; set; }
        public string DraftActive { get; set; }
        public DateTime? LateDate { get; set; }
        public string Email { get; set; }
        public string Password  { get; set; }

    }
}