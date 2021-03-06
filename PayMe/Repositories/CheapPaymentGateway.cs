using PayMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayMe.PaymentHelpers.Stripe.Gateway;
using PayMe.DBContext;
using Microsoft.EntityFrameworkCore;

namespace PayMe.Repositories
{
    public class CheapPaymentGateway : ICheapPaymentGateway
    {
        private PaymentDbContext context;
        private DbSet<Payment> paymentEntity;
        private DbSet<PaymentState> paymentStateEntity;

        public CheapPaymentGateway(PaymentDbContext context)
        {
            this.context = context;
            paymentEntity = context.Set<Payment>();
            paymentStateEntity = context.Set<PaymentState>();
        }

        public Response ProcessPaymentCheap(CardTransactionDetails ctd)
        {
            Payment paymentObj = new Payment();


            //Random generator = new Random();
            //int payId = generator.Next(1, 1000000);

            paymentObj.cardCVV = !string.IsNullOrEmpty(ctd.cardCVV)?int.Parse(ctd.cardCVV):0;
            paymentObj.cardExp = ctd.cardExp;
            paymentObj.cardNumber = ctd.cardNumber;
            paymentObj._cardTypes = "1";
            paymentObj.cardHolder = ctd.cardHolder;
            //paymentObj.Id = payId;

            var _result= StripePayment.Pay(ctd);

            //payId
            PaymentState psObject = new PaymentState();
           // psObject.Id = payId;
            psObject.status = _result.statusCode.ToString();
            psObject.details = _result.message;
            psObject.payment = paymentObj;
                

            paymentStateEntity.Add(psObject);
            context.SaveChanges();

            return _result;
        }
    }
}
