using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Models
{
    public interface IJungleRepository
    {
        IQueryable<Book> Books { get; }
    }
}
