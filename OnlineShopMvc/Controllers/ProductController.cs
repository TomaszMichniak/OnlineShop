using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Product;
using OnlineShop.Application.Product.Commands.CreateProduct;
using OnlineShop.Application.Product.Commands.DeleteProduct;
using OnlineShop.Application.Product.Queries.GetAllProducts;

namespace OnlineShopMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string encodedName)
        {
            await _mediator.Send(new DeleteProductCommand(encodedName));
            return RedirectToAction("Index");
        }
    }
}
