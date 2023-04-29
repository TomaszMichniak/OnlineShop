using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.ProductRating.Commands.Create
{
    public class CreateProductRatingCommandValidator : AbstractValidator<CreateProductRatingCommand>
    {
        public CreateProductRatingCommandValidator() {

            RuleFor(x => x.Rating)
                .GreaterThan(0)
                .LessThan(6);
            
        }
    }
}
