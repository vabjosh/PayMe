using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayMe.Controllers;
using PayMe.Model;
using PayMe.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayMe.Controllers.Tests
{
    [TestClass()]
    public class TransactControllerPaymentTests
    {
        //private readonly TransactController _obj;
        //private readonly ILogger<TransactController> _logger;
        //private readonly IPaymentService _paymentService;
        //TransactControllerPaymentTests(TransactController obj, ILogger<TransactController> logger, IPaymentService payementservice)
        //{
        //    _obj = obj;
        //    _logger = logger;
        //    _paymentService = payementservice;
        //}
        //[TestInitialize]
        //public void Initalize()
        //{
        //    _loggingService = new LoggingService();
        //    _userManager = new UserManager();
        //}
        [TestMethod()]
        public void ProcessPaymentTest()
        {


            TransactController tc = new TransactController(_logger, _paymentService);
            CardTransactionDetails ctd = new CardTransactionDetails();
            ctd.amount = 400;
            ctd.cardCVV = "333";
            ctd.cardExp = "04/23";
            ctd.cardHolder = "Andrew Malik";
            ctd.cardNumber = "5596320408704568";
            ctd._cardTypes = CardTransactionDetails.CardType.All;

            
            var _result = (Response).ProcessPayment(ctd);
            Assert.AreEqual(_result.statusCode, 200);
        }
    }
}