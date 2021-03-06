using PayMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.PaymentHelpers.Stripe.Gateway
{
   public interface IStripe
    {
        public   Response Pay(CardTransactionDetails details, string type = "");
    }
}
