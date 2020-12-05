using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.TechnoStore.Web.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı"), Required(ErrorMessage = "Bu alan gereklidir.")]
        public string UserName { get; set; }

        [Display(Name = "Şifre"), Required(ErrorMessage = "Bu alan gereklidir."), DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
