using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CRUD_MVC.Models
{
    public class CEmployee
    {
        [Key]
        public int fId { get; set; }

        [Required(ErrorMessage ="請輸入員工姓名")]
        [DisplayName("員工姓名")]
        public string fEmpName { get; set; }

        [Required(ErrorMessage = "請輸入員工信箱")]
        [DisplayName("員工信箱")]
        [DataType(DataType.EmailAddress)]
        public string fEmail { get; set; }

        [Required(ErrorMessage = "請輸入員工年齡")]
        [DisplayName("員工年齡")]
        [Range(20,50)]
        public int fAge { get; set; }

        [Required(ErrorMessage = "請輸入薪資")]
        [DisplayName("薪資")]
        public int fSalary { get; set; }
    }
}
