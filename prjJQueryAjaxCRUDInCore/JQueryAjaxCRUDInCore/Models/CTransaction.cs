using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JQueryAjaxCRUDInCore.Models
{
    public class CTransaction
    {
        [Key]
        public int fTranId { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage ="This field is required")]
        [DisplayName("Account Number")]
        [Column(TypeName = "nvarchar(12)")]
        public string fAccountNum { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Beneficiary Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string fBeneficiaryName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Bank Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string fBankName { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("SWIFT Code")]
        [Column(TypeName = "nvarchar(11)")]
        public string fSwiftCode { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Amount")]
        public int fAmount { get; set; }

        [DisplayName("Date")]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
        public DateTime fDate { get; set; }
    }
}
