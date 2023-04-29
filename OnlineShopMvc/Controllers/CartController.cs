using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Cart.Commands.AddToCartCommand;

namespace OnlineShopMvc.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly IMediator _mediator;

		public CartController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Route("Koszyk/Dodanie/{encodedNameProduct}")]
		public async Task<IActionResult> AddToCart(string encodedNameProduct)
		{
			await _mediator.Send(new AddToCartCommand() { EncodedNameProduct = encodedNameProduct });
			return RedirectToAction("Index","Product");
		}
	}
}
