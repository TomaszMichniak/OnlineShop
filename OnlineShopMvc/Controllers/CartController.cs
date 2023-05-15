using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Cart.Commands.AddToCartCommand;
using OnlineShop.Application.Cart.Commands.DeleteFromCartCommand;
using OnlineShop.Application.Cart.Commands.MinusCount;
using OnlineShop.Application.Cart.Commands.PlusCount;
using OnlineShop.Application.Cart.Queries.GetCartQuery;
using OnlineShopMvc.Extensions;

namespace OnlineShopMvc.Controllers
{
	[Authorize]
	[Route("Koszyk")]
	public class CartController : Controller
	{
		private readonly IMediator _mediator;

		public CartController(IMediator mediator)
		{
			_mediator = mediator;
		}
		

		[Route("/Dodanie/{encodedNameProduct}")]
		public async Task<IActionResult> AddToCart(string encodedNameProduct)
		{
			await _mediator.Send(new AddToCartCommand() { EncodedNameProduct = encodedNameProduct });
			this.SetNotification("success", "Produkt został dodany do koszyka");
            return RedirectToAction("Index","Product");
		}
		public async Task<IActionResult> Index()
		{
			var data = await _mediator.Send(new GetCartQuery());
			return View("Index",data);
		}
		[Route("/Usuniecie/{productEncodedName}")]
		public async Task<IActionResult> Delete(string productEncodedName)
		{
			await _mediator.Send(new DeleteFromCartCommand() { ProductEncodedName= productEncodedName});
            this.SetNotification("success", "Produkt został usunięty z koszyka");
            return RedirectToAction("Index");
		}
		[Route("/Zwiekszenie-Ilości/{productEncodedName}")]
		public async Task<IActionResult> PlusCount(string productEncodedName)
		{
			await _mediator.Send(new PlusCountCommand(productEncodedName));
			return RedirectToAction("Index");
        }
        [Route("/Zmniejszenie-Ilości/{productEncodedName}")]
		public async Task<IActionResult> MinusCount(string productEncodedName)
		{
            await _mediator.Send(new MinusCountCommand(productEncodedName));
            return RedirectToAction("Index");
        }
    }
}
