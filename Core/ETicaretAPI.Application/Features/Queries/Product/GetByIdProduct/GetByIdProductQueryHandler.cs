﻿using ETicaretAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct
{
	public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
	{
		readonly IProductReadRepository _productReadRepository;

		public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
		{
			_productReadRepository = productReadRepository;
		}

		public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
		{
			Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
			return new()
			{
				Description = product.Description,
				Name = product.Name,
				Price = product.Price,
				Stock = product.Stock
			};

		}
	}
}
