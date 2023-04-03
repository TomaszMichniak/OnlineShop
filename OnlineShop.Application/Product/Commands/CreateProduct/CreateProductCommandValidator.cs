using FluentValidation;
using OnlineShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator :AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator(IProductsRepository repository) 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Wprowadź nazwe")
                .MinimumLength(3).WithMessage("Nazwa musi zawierać przynajmniej 3 znaki")
                .MaximumLength(20).WithMessage("Nazwa nie może przekroczyć 20 znaków")
                .Custom((value, context) =>
                {
                    var product = repository.GetByName(value).Result;
                    if (product != null)
                    {
                        context.AddFailure($"Nazwa \"{value}\" jest już zajeta ");
                    }
                }
                )
                ;

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Wprowadź opis");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Wprowadź cene")
                .GreaterThan(0).WithMessage("Cena musi być wieksza niz 0");
        
        }
    }
}
