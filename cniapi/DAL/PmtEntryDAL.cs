using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cniapi.DAL
{
    [Table("PmtEntry")]
    public partial class PmtEntryDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PmtEntryId { get; set; }

        public int CustNum { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ExportDate { get; set; }

        public int? Status { get; set; }

        [StringLength(20)]
        public string PmtType { get; set; }

        public double? PmtAmount { get; set; }

        public double? PmtFee { get; set; }

        [StringLength(30)]
        public string Reference { get; set; }

        [StringLength(30)]
        public string Processor { get; set; }

    }
}