using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Checkout> Donations => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public IQueryable<Checkout> Purchases => throw new NotImplementedException();

        public void SavePurchase(Checkout purchase)
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                context.Purchases.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
