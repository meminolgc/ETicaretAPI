﻿using ETicaretAPI.Application.Repositories.Product;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories.Product
{
	public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
	{
		public ProductWriteRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
