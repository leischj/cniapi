using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cniapi.DAL
{
    [Table("History")]
    public partial class HistoryDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistId { get; set; }

        public int CustNum { get; set; }

        public DateTime? PostDate { get; set; }

        [StringLength(4)]
        public string TranSource { get; set; }

        [StringLength(255)]
        public string TranDesc { get; set; }

        public int? TranCount { get; set; }

        public double? Amount { get; set; }

        public Boolean? IsBudget { get; set; }

        public double? ResultBalance { get; set; }

        public double? ResultBudget { get; set; }
    }
}