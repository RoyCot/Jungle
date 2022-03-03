using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Models
{
    public interface IPurchaseRepository
    {
        public IQueryable<Checkout> Purchases { get; }

        public void SavePurchase(Checkout purchase);
    }
}
