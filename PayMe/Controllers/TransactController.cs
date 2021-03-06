using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PayMe.Model;
using PayMe.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayMe.Services;
namespace PayMe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactController : ControllerBase
    {
        private readonly ILogger<TransactController> _logger;
        private readonly IPaymentService _paymentService;
        public TransactController(ILogger<TransactController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }
 

        [HttpPost]
        public object ProcessPayment(CardTransactionDetails pInput)
        {
            Response response = new Response();
            try 
            {
                 
                CardValidator cv = new CardValidator();
                var result = cv.Validate(pInput);
                if (result.IsValid)
                {
                  Response _result=  _paymentService.ProcessPayment(pInput);

                    if (_result.statusCode == 200)
                    {
                        
                        response.statusCode = 200;
                        response.message = "Payment is processed";
                        

                    }
                    else
                    {
                        response.statusCode = _result.statusCode;
                        response.message = _result.message;

                    }
                }
                else
                {
                   
                    response.statusCode = 400;
                    response.message = "The request is invalid";
                    
                    
                }
            } 
            catch(Exception ex)
            {
                
                response.statusCode = 500;
                response.message = "Any error: 500 internal server error";
                
            }

            return response;
            
        }
    }
}
