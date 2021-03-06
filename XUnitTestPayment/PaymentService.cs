using PayMe.Model;
using PayMe.Repositories;
using PayMe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestPayment.PaymentService
{
  public  class PaymentService : IPaymentService
    {
        private readonly IExpensivePaymentGateway paymentExpRepository;

        private readonly ICheapPaymentGateway paymentChpRepository;
        private readonly IPremiumPaymentGateway paymentPrmRepository;

        public PaymentService(IExpensivePaymentGateway paymentExpRepository, ICheapPaymentGateway paymentChpRepository, IPremiumPaymentGateway paymentPrmRepository)
        {
            this.paymentExpRepository = paymentExpRepository;
            this.paymentChpRepository = paymentChpRepository;
            this.paymentPrmRepository = paymentPrmRepository;
        }
        public Response ProcessPayment(CardTransactionDetails ctd)
        {
            Response resultobj = null;
            if (ctd.amount <= 20)
            {
                resultobj = paymentChpRepository.ProcessPaymentCheap(ctd);
            }
            else if (ctd.amount >= 21 && ctd.amount <= 500)
            {
                try
                {
                    resultobj = paymentExpRepository.ProcessPaymentExpensive(ctd);
                }
                catch (Exception ex)
                {
                    try
                    {
                        resultobj = paymentChpRepository.ProcessPaymentCheap(ctd);
                    }
                    catch (Exception exc)
                    {
                        resultobj.statusCode = 500;
                        resultobj.message = exc.Message;
                    }
                }

            }
            else if (ctd.amount > 500)
            {
                resultobj = paymentPrmRepository.ProcessPaymentPrem(ctd);
            }

            return resultobj;
        }
    }
}
