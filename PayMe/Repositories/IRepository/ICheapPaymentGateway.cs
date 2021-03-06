using PayMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.Repositories
{
    public interface ICheapPaymentGateway
    {
       public Response ProcessPaymentCheap(CardTransactionDetails ctd);
     }
}
