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
    }
}
