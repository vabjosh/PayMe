using FluentValidation;
using PayMe.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayMe.Validator
{
    public class CardValidator:AbstractValidator<CardTransactionDetails>
    {
        public CardValidator()
        {
            RuleFor(m => m.cardNumber).CreditCard();
            RuleFor(m => m.cardHolder).NotEmpty();
            RuleFor(m => m.cardExp).NotEmpty();             
            RuleFor(m => m.cardPin).NotEmpty();
            RuleFor(m => m.amount).GreaterThan(0);
        }
    }
}
