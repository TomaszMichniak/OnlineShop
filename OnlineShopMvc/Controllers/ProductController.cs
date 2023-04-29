using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Paginations;
using OnlineShop.Application.Product.Commands.CreateProduct;
using OnlineShop.Application.Product.Commands.DeleteProduct;
using OnlineShop.Application.Product.Queries.GetAllProducts;
using OnlineShop.Application.Product.Queries.GetProduct;
using OnlineShop.Application.ProductRating.Commands.Create;
using OnlineShop.Application.ProductRating.Commands.Delete;
using OnlineShop.Application.ProductRating.Query;
using Microsoft.AspNetCore.Http;

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
        [Route("Produkty")]
        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return View(products);
        }
        [Route("Produkty/{encodedName}")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var product = await _mediator.Send(new GetProductByEncodedNameQuery(encodedName));
            return View(product);
        }
        [Route("Produkty/Tworzenie")]
        public IActionResult Create()
        {
            return View();
        }
        [Route("Produkty/Tworzenie")]
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
        [Route("Produkty/Usuwanie")]
        public async Task<IActionResult> Delete(string encodedName)
        {
            await _mediator.Send(new DeleteProductCommand(encodedName));
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        [Route("Produkty/Komenatrze/Tworzenie")]
        public async Task<IActionResult> CreateProductRating(CreateProductRatingCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        [Route("Produkty/{encodedName}/Komentarze/{pagination?}")]
        public async Task<IActionResult> GetProductRatings(string encodedName, Pagination? pagination)
        {
            var data = await _mediator.Send(new GetProductRatingsQuery() { EncodedName = encodedName, Pagination = pagination });
            return Ok(data);
        }

        [Route("Produkty/{encodedName}/Komentarze/Delete/{id}")]
        public async Task<IActionResult> DeleteProductRating(int id,string encodedName)
        {
            await _mediator.Send(new DeleteProductRatingCommand() { Id = id });
            return RedirectToAction("Details",new { encodedName });

        }
    }
}
