using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.ViewModels
{
    public class CLogin
    {
        [DisplayName("帳號")]
        public string fUserName { get; set; }

        [DisplayName("密碼")]
        public string fPassword { get; set; }
    }
}
