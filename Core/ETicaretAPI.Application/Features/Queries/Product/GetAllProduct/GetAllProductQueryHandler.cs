using ETicaretAPI.Application.DTOs.Product;
using ETicaretAPI.Application.Repositories.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProduct
{
	public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
	{
		readonly IProductReadRepository _productReadRepository;

		public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
		{
			_productReadRepository = productReadRepository;
		}

		public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
		{
			var products = await _productReadRepository.GetAll().ToListAsync();

			var productDtos = products.Select(p => new GetAllProductDto
			{
				Description = p.Description,
				Name = p.Name,
				Price = p.Price,
				Stock = p.Stock
			}).ToList();

			return new()
			{
				Products = productDtos
			};
		
		}
	}
}
