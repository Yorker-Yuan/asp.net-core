using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIIInlinetable.Models
{
    public class CBankAccount
    {
        [Key]
        public int fBankAccountId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(20)")]
        public string fAccountNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string fAccountHolder { get; set; }

        [Required]
        public int fBankId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string fIFSC { get; set; }

    }
}
