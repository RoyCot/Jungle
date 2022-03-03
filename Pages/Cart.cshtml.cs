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

        public ShoppingCart sc { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel (IJungleRepository temp, ShoppingCart shop)
        {
            repo = temp;
            sc = shop;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            sc.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            sc.RemoveItem(sc.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
