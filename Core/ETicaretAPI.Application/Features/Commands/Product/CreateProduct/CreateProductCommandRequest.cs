﻿using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}
