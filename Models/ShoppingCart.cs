using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartLineItem> Items { get; set; } = new List<ShoppingCartLineItem>();

        public virtual void AddItem(Book b, int qty)
        {
            ShoppingCartLineItem line = Items.Where(x => x.Book.BookId == b.BookId).FirstOrDefault();

            if (line == null)
            {
                Items.Add(new ShoppingCartLineItem
                {
                    Book = b,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Book b)
        {
            Items.RemoveAll(x => x.Book.BookId == b.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);

            return sum;
        }
    }

    public class ShoppingCartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
