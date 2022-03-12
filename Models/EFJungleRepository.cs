using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Models
{
    public class EFJungleRepository : IJungleRepository
    {
        private BookstoreContext context { get; set; }

        public EFJungleRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
