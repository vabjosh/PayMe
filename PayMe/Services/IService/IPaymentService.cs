using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayMe.Model;

namespace PayMe.Services
{
   public interface IPaymentService
    {
        public Response ProcessPayment(CardTransactionDetails ctd);
    }
}
