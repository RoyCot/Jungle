using Jungle.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Controllers
{
    public class PurchaseController : Controller
    {
        public IPurchaseRepository repo { get; set; }
        public ShoppingCart sc { get; set; }

        public PurchaseController(IPurchaseRepository temp, ShoppingCart shop)
        {
            repo = temp;
            sc = shop;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout purchase)
        {
            if (sc.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = sc.Items.ToArray();
                repo.SavePurchase(purchase);
                sc.ClearCart();

                return RedirectToPage("/PurchaseVerified");
            }
            else
            {
                return View();
            }
        }
    }
}
