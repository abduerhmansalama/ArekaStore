using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class StoreCreditCardModel
    {
        [Required(ErrorMessage ="CreditCard Number is rquired")]
        [MinLength(15,ErrorMessage ="please enter availd card Number ")]
        [MaxLength(19,ErrorMessage ="Please enter Availd Number")]
        public string Number  { get; set; }

        [Required(ErrorMessage = "ExpireMonth Number is rquired")]
        [Display(Name="ExpireMonth")]
        public int ExpireMonth  { get; set; }

        [Required(ErrorMessage ="ExipreYear Number is Required")]
        [Display(Name ="ExpireYear")]
        public int ExpireYear { get; set; }

        [Required(ErrorMessage ="CVV is Ruquired ")]
        public String Cvv { get; set; }


    }
}
