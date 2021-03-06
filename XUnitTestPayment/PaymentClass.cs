using PayMe.Controllers;
using PayMe.Services;
using System;
using Xunit;
using XUnitTestPayment.PaymentService;
namespace XUnitTestPayment
{
    public class PaymentClass
    {
        TransactController _controller;
        IPaymentService _service;

        public PaymentClass()
        {
            _service=new pay
        }

        [Fact]
        public void TestPayment()
        {

        }
    }
}
