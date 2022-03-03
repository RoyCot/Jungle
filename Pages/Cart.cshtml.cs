using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jungle.Infrastructure;
using Jungle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jungle.Pages
{
    public class CartModel : PageModel
    {
        private IJungleRepository repo { get; set; }

        public CartModel (IJungleRepository temp)
        {
            repo = temp;
        }

        public ShoppingCart sc { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            sc = HttpContext.Session.GetJson<ShoppingCart>("sc") ?? new ShoppingCart();
        }

        public IActionResult OnPost(int bookId)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            sc = HttpContext.Session.GetJson<ShoppingCart>("sc") ?? new ShoppingCart();
            sc.AddItem(b, 1);

            HttpContext.Session.SetJson("sc", sc);

            return RedirectToPage(new { ReturnUrl = ReturnUrl });
        }
    }
}
