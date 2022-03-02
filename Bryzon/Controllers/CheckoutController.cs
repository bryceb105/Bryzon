using Bryzon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Controllers
{
    public class CheckoutController : Controller
    {
        //Pass basket through
        private ICheckoutRepository repo { get; set; }
        private Basket basket { get; set; }
        public CheckoutController(ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        //Get Checkout Values
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }
        
        //Post Values
        [HttpPost]
        public IActionResult Checkout (Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if(ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearBasket();

                return RedirectToPage("/CheckoutCompleted");
            }

            else
            {
                return View();
            }
        }

    }
}
