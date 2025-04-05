using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Admin")]

	public class ProductsController : ControllerBase
	{
		readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{Id}")]
		public async Task<IActionResult> GetProductById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
		{
			GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
			return Ok(response);
		}
		[HttpGet("GetAllProducts")]
		public async Task<IActionResult> GetAllProducts()
		{
			var result = await _mediator.Send(new GetAllProductQueryRequest());
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
		{
			CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
			return Ok(response);
		} 

		[HttpDelete] 
		public async Task<IActionResult> RemoveProduct(RemoveProductCommandRequest removeProductCommandRequest)
		{
			RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
			return Ok(response);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
		{
			UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
			return Ok();
		}
	}
}
