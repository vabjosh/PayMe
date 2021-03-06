using PayMe.Model;
using Stripe;
using System;
using Polly;
using Polly.CircuitBreaker;
using System.Net.Http;

namespace PayMe.PaymentHelpers.Stripe.Gateway
{
    public static class StripePayment
    {
        private static int _count=3;
        
        

        public static Response Pay(CardTransactionDetails details,string type="")
        {
            Response res = new Response();
            try
            {
                                    
                    
                StripeConfiguration.ApiKey= "sk_test_51IRzyvD0VkN7oP9GVQ5P89GV2g1sFggp3sxvpsMYKhQLgqoIYnYBa1AhIPlf3mrPAAOhzoVPyRTYWzW39FvV9sBv00jGRtENB4";
                var optionTokens = new TokenCreateOptions
                {
                    Card = new CreditCardOptions
                    {
                        Number = details.cardNumber,
                        ExpYear = int.Parse(details.cardExp.Split("/")[1]),
                        ExpMonth = int.Parse(details.cardExp.Split("/")[0]),
                        Cvc = details.cardCVV,
                        Name = details.cardHolder
                    }
                };

                var servicetoken = new TokenService();
                Token stripeToken = servicetoken.Create(optionTokens);
                
                var options = new ChargeCreateOptions
                {
                    Amount = Convert.ToInt64(details.amount),
                    Currency = "eur",
                    Description = "test",
                    Source = stripeToken.Id
                };

                var service = new ChargeService();


                Charge charge;
                charge = service.Create(options);

                if (charge.Paid)
                {
                    res.message = "Success";
                    res.statusCode = 200;
                    return res;
                }
                else
                {
                    res.message = "Bad Request";
                    res.statusCode = 400;
                    return res;                    
                }
            }
            catch (Exception e)
            {
                if (_count != 0 && type=="prem")
                {
                    _count--;
                    Pay(details, "prem");
                }               
                res.message = string.Concat("Server Error: ",e.Message);
                res.statusCode = 500;
                return res;
            }
        }
   
    }
}
