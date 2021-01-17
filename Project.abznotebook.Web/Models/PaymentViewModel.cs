using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.abznotebook.Entities.Concrete;

namespace Project.abznotebook.Web.Models
{
    public class PaymentViewModel : OrderViewModel
    {
        [Required(ErrorMessage = "Kart Sahibi Giriniz.")]
        public string Cardholder { get; set; }

        [Required(ErrorMessage = "Kart Numarası Giriniz.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string ExpiredMonth { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string ExpiredYear { get; set; }

        [Required(ErrorMessage = "CVV Giriniz")]
        public string CVV { get; set; }

    }
}
