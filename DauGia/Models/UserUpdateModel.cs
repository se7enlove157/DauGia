using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class UserUpdateModel
    {
        public string FullName { get; set; }
        public string PasswordOld { get; set; }
        public string PasswordNew { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

    }
}