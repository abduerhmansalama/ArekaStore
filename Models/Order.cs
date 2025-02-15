﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Areas.Identity.Data;

namespace WebApplication2.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Street")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your state")]
      
        public string State { get; set; }

        //[Required(ErrorMessage = "Please enter your zip")]
        //[StringLength(5, MinimumLength = 5)]
        //[Display(Name = "Zip Code")]
        //public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your phone")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public double TotalPrice { get; set; }


        [ForeignKey("Order_Statues")]
        public int? Order_statues_ID { get; set; }

        [ForeignKey("User")]
        public string IdIdentity { get; set; }
        public List<OrderProduct> orderProducts { get; set; }

        [ForeignKey("PaymentMethod")]
        public int? Payment_ID { get; set; }

        //[BindNever]
        //public decimal OrderTotal { get; set; }

        //[BindNever]
        //public DateTime OrderPlaced { get; set; }



        public PaymentMethod PaymentMethod { get; set; }
       
        public Order_Statues Order_Statues { get; set; }
        public UsingIdentityUser usingIdentity { get; set; }
    }
}
