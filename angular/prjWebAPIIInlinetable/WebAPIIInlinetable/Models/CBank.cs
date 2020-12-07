using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIIInlinetable.Models
{
    public class CBank
    {
        [Key]
        public int fBankId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string fBankName { get; set; }
    }
}
