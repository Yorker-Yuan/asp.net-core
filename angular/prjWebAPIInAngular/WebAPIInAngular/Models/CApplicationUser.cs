using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIInAngular.Models
{
    public class CApplicationUser
    {   //在postman上以此為傳遞參數
        public string fUserName { get; set; }

        public string fEmail { get; set; }

        public string fPassword { get; set; }

        public string fFullName { get; set; }
    }
}
