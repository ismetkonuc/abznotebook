using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.abznotebook.Web.Areas.Member.Models
{
    public class EditUserViewModel
    {

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Zorunlu alan")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare("NewPassword", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string NewPasswordConfirmation { get; set; }

        public string Tel { get; set; }

    }
}
