using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace cniapi.DAL
{
    [Table("Services")]
    public partial class ServiceDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SrvcId { get; set; }

        public int? LineId { get; set; }
        public int? CustNum { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(10)]
        public string SrvcClass { get; set; }

        [StringLength(20)]
        public string SrvcCategory { get; set; }

        [StringLength(4)]
        public string SrvcRate { get; set; }

        [StringLength(4)]
        public string SrvcLC { get; set; }

        [StringLength(4)]
        public string SrvcTax { get; set; }

        [StringLength(4)]
        public string SrvcType { get; set; }

        [StringLength(30)]
        public string SrvcDesc { get; set; }

        public DateTime? DepositDate { get; set; }

        [StringLength(6)]
        public string DepositNum { get; set; }

        public double? DepositAmt { get; set; }
    }
}