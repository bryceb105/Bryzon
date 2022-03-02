using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Models
{
//Pursharing repo
    public interface ICheckoutRepository
    {
        IQueryable<Checkout> Checkout { get; }

        void SaveCheckout(Checkout checkout);
    }
}
