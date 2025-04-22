using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Basket;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Persistence.Services
{
	public class BasketService : IBasketService
	{
		public Task AddItemToBasketAsync(CreateBasketItemDto basketItem)
		{
			throw new NotImplementedException();
		}

		public decimal CalculateTotalPrice(int basketId)
		{
			throw new NotImplementedException();
		}

		public Task<List<BasketItem>> GetBasketItemsAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveBasketItemAsync(int basketItemId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateQuantityAsync(UpdateBasketItemDto basketItem)
		{
			throw new NotImplementedException();
		}
	}
}
