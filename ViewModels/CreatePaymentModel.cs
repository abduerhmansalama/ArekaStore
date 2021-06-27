using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.ViewModels
{
    public class CreatePaymentModel:StoreCreditCardModel
    {
        [Required(ErrorMessage ="Please Enter how much like to pay?")]
        public long Money { get; set; }
    }
}
