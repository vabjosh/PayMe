using PayMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.Repositories
{
   public interface IExpensivePaymentGateway
    {
       public Response ProcessPaymentExpensive(CardTransactionDetails ctd);
    }
}
