using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIInAngular.Models
{
    public class CApplicationUser
    {   //在postman上以此為傳遞參數
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
    }
}
