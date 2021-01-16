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
        [Required(ErrorMessage = "Doldurulması Zorunlu Alan")]
        public string Cardholder { get; set; }

        //[CreditCard(ErrorMessage = "Kredi Kartını Doğru Formatta Giriniz.")]
        [Required(ErrorMessage = "Doldurulması Zorunlu Alan")]
        public string CardNumber { get; set; }

        [Required( ErrorMessage = "Ay Seçiniz")]
        public int ExpiredMonth { get; set; }

        [Required(ErrorMessage = "Yıl Seçiniz")]
        public int ExpiredYear { get; set; }

        [Required(ErrorMessage = "CVV Giriniz")]
        public short CVV { get; set; }

        public SelectList MonthCollection { get; set; }
        public SelectList YearCollection { get; set; }
    }
}
