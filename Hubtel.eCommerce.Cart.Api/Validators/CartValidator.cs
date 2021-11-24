using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Hubtel.eCommerce.Cart.Api.Validators
{
    public class CartValidator : AbstractValidator<Models.Cart>
    {
        public CartValidator()
        {
            RuleFor(p => p.ItemName).NotEmpty();
            RuleFor(p => p.PhoneNumber).NotEmpty().MustMatchPhoneNumber();
            RuleFor(p => p.ItemId).NotNull().Must(IsMoreThanZero).WithMessage("Item ID should be 1 or more.");
            RuleFor(p => p.Quantity).NotNull().Must(IsMoreThanZero).WithMessage("Qty should be 1 or more.");
        }

        private static bool IsMoreThanZero(int value) => value > 0;
    }

    internal static class Extensions
    {
        public static IRuleBuilderOptions<T, string> MustMatchPhoneNumber<T>(this IRuleBuilder<T, string> rule)
            => rule.Matches("^[0-9]*$").WithMessage("Invalid phone number");
    }
}
