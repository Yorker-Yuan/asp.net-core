using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels
{
    public class CRegister
    {
        public int fUserId { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage ="輸入信箱")]
        [DataType(DataType.EmailAddress)]
        public string fEmail { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "輸入密碼")]
        [DataType(DataType.Password)]
        public string fPassword { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "再次輸入密碼")]
        [DataType(DataType.Password)]
        [Compare("fPassword",ErrorMessage ="密碼不一致")]
        public string fPasswordConfirm { get; set; }
    }
}
