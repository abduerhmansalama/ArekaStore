using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class Paymentcontroller : Controller
    {
        private double totalprice;
        public IActionResult CheckOut(orderDetails orderDetails)
        {
            ViewBag.tot = orderDetails.TotalPrice;
            totalprice = orderDetails.TotalPrice;
            ViewBag.details = orderDetails;
            ViewBag.fname = orderDetails.FirstName;
            ViewBag.lname = orderDetails.LastName;
            ViewBag.PhoneNumber = orderDetails.PhoneNumber;
            ViewBag.Address = orderDetails.Address;
            ViewBag.City = orderDetails.City;
            ViewBag.State = orderDetails.State;
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(CreatePaymentModel model)
        {
            StripeConfiguration.ApiKey = "sk_test_51IvA1xCnMVGmuI8SdFdqhnvk8ID1hsMY6M3V7juTBpKliDE4U1hc3khW7gpVSbrlgjbf3c4YvtXH34zJOeAYm9ZX00X0sB22hh";
            //model.Money=(long) HttpContext.Session.GetInt32("TotalPrice");
            model.Money = (long)totalprice;
            var NewCreditCardToken = StoreCreditCard(new CreatePaymentModel()
                {
                    Number = model.Number,
                    ExpireMonth = model.ExpireMonth,
                    ExpireYear = model.ExpireYear,
                    Cvv = model.Cvv

                });

                var myCharge = new ChargeCreateOptions
                {
                    Amount = model.Money * 100,
                    Currency = "usd",
                    Source = NewCreditCardToken
                };

                var chargeService = new ChargeService();
                var stripeCharge = chargeService.Create(myCharge);


            var status = stripeCharge.Status;
            if (status == "succeeded")
                TempData["SucessMessage"] = "Payment sucess";
            return View(model);

        }
        public string StoreCreditCard(StoreCreditCardModel model)
        {
            var Options = new TokenCreateOptions
            {
                Card =new TokenCardOptions {
                    Number=model.Number,
                    ExpYear=model.ExpireYear,
                    ExpMonth=model.ExpireMonth,
                    Cvc=model.Cvv
                
                } 

            };
            var service = new TokenService();
            Token stripeToken = service.Create(Options);
            return stripeToken.Id;
           
        }
    }
}
