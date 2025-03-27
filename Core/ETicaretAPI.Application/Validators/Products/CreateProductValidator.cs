using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
	public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
	{
		public CreateProductValidator()
		{
			RuleFor(p => p.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Ürün adı boş geçilemez")
				.MaximumLength(100)
				.MinimumLength(3)
				.WithMessage("Ürün adı minimum 3 maksimum 100 karakter olabilir.");

			RuleFor(p => p.Description)
				.MaximumLength(450)
				.WithMessage("Açıklama uzunluğu 450 karakterden fazla olamaz!");

			RuleFor(p => p.Stock)
			   .NotEmpty()
			   .NotNull()
				   .WithMessage("Lütfen stok bilgisini boş geçmeyiniz.")
			   .Must(s => s >= 0)
				   .WithMessage("Stok bilgisi negatif olamaz!");

			RuleFor(p => p.Price)
			   .NotEmpty()
			   .NotNull()
				   .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
			   .Must(s => s >= 0)
				   .WithMessage("Fiyat bilgisi negatif olamaz!");
		}
	}
}
