﻿using ETicaretAPI.Application.Repositories.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
	public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
	{
		readonly IProductReadRepository _productReadRepository;
		readonly IProductWriteRepository _productWriteRepository;

		public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
		{
			_productReadRepository = productReadRepository;
			_productWriteRepository = productWriteRepository;
		}

		public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
		{
			Domain.Entities.Product product = await _productReadRepository.GetByIdAsync(request.Id);
			product.Name = request.Name;
			product.Description = request.Description;
			product.Price = request.Price;
			product.Stock = request.Stock;
			await _productWriteRepository.SaveAsync();
			return new();
		}
	}
}
