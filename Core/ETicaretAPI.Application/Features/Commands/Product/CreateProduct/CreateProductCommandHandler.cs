﻿using ETicaretAPI.Application.Repositories.Product;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
	{
		readonly IProductWriteRepository _productWriteRepository;

		public CreateProductCommandHandler(IProductWriteRepository productWriteRepository)
		{
			_productWriteRepository = productWriteRepository;
		}

		public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = await _productWriteRepository.AddAsync(new Domain.Entities.Product
			{
				Name = request.Name,
				Price = request.Price,
				Stock = request.Stock,
				Description = request.Description
			});

			await _productWriteRepository.SaveAsync();
			return new CreateProductCommandResponse
			{
				Success = true,
				Message = "Product created successfully.",
				ProductId = product.Id
			};
		}
	}
}
