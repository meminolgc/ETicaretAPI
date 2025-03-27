﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
	public class CreateProductCommandResponse
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public int ProductId { get; set; }
	}
}
