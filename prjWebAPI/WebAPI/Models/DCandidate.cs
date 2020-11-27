using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DCandidate
    {
        [Key]
        public int fID { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string fFullName { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string fMobile { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string fEmail { get; set; }

        public int fAge { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string fBloodGroup { get; set; } //血型

        [Column(TypeName = "nvarchar(100)")]
        public string fAddress { get; set; }
    }
}
