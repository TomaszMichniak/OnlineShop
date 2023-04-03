using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Mapping;
using OnlineShop.Application.Product.Commands.CreateProduct;

namespace OnlineShop.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddApplication(this IServiceCollection Services) {

            Services.AddAutoMapper(typeof(ProductsMappingProfil));
            Services.AddMediatR(typeof(CreateProductCommand));

            Services.AddValidatorsFromAssemblyContaining(typeof(CreateProductCommandValidator))
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
