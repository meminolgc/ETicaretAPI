using ETicaretAPI.Application.DTOs.Basket;
using ETicaretAPI.Domain.Entities;

namespace ETicaretAPI.Application.Abstractions.Services
{
	public interface IBasketService
	{
		public Task<List<BasketItem>> GetBasketItemsAsync();
		public Task AddItemToBasketAsync(CreateBasketItemDto basketItem);
		public Task UpdateQuantityAsync(UpdateBasketItemDto basketItem);
		public Task RemoveBasketItemAsync(int basketItemId);
		decimal CalculateTotalPrice(int basketId);
	}
}
