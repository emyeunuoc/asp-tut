using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Moi nhap vao username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Moi nhap vao password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}