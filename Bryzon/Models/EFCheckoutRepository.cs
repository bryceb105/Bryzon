using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Models
{
    public class EFCheckoutRepository : ICheckoutRepository
    {
        private BookstoreContext context;
        public EFCheckoutRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Checkout> Checkout => context.Checkout.Include(p => p.Lines).ThenInclude(p => p.Book);

        public void SaveCheckout(Checkout checkout)
        {
            context.AttachRange(checkout.Lines.Select(p => p.Book));

            if (checkout.CheckoutId == 0)
            {
                context.Checkout.Add(checkout);
            }

            context.SaveChanges();
        }
    }
}
