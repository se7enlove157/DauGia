using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DauGia.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int Level { get; set; } // phân quyền 1 quản trị, 2 thành viên đăng kí, 3 user
        public string Address { get; set; }
        public string Email { get; set; }


    }
}