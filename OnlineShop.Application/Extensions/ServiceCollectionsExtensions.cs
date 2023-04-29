using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.ApplicationUser;
using OnlineShop.Application.Mapping;
using OnlineShop.Application.Product.Commands.CreateProduct;

namespace OnlineShop.Infrastructure.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddApplication(this IServiceCollection Services) {

			Services.AddScoped<IUserContext, UserContext>();
            Services.AddMediatR(typeof(CreateProductCommand));

			Services.AddScoped(provider => new MapperConfiguration(cfg =>
			{
				var scope = provider.CreateScope();
				var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
				cfg.AddProfile(new ProductsMappingProfil(userContext));
			}).CreateMapper()
			);

			Services.AddValidatorsFromAssemblyContaining(typeof(CreateProductCommandValidator))
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
