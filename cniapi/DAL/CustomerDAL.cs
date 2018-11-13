using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cniapi.DAL
{
    [Table("Customers")]
    public partial class CustomerDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustNum { get; set; }

        public int? Route { get; set; }

        public int? Account { get; set; }

        public int? Sub { get; set; }

        public int? Cycle { get; set; }


        [StringLength(1)]
        public string Status { get; set; }

        public DateTime? ActivationDate { get; set; }

        [StringLength(255)]
        public string DriverLicense { get; set; }

        [StringLength(11)]
        public string SocSecNum { get; set; }

        [StringLength(12)]
        public string WorkPhone { get; set; }

        [StringLength(12)]
        public string HomePhone { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(24)]
        public string BillAddress1 { get; set; }

        [StringLength(24)]
        public string BillAddress2 { get; set; }

        [StringLength(15)]
        public string BillCity { get; set; }

        [StringLength(2)]
        public string BillState { get; set; }

        [StringLength(10)]
        public string BillZip { get; set; }

        [StringLength(32)]
        public string ServiceAddress { get; set; }

        [StringLength(32)]
        public string PaymentComment { get; set; }

        public float? PastDue { get; set; }

        public float? CurrentDue { get; set; }

        public float? TotalDue { get; set; }

        public float? BudgetPymtAmt { get; set; }

        [StringLength(1)]
        public string DraftActive { get; set; }

        public DateTime? LateDate { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }


    }
}