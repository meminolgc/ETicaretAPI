using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories.BasketItem
{
	public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem>, IBasketItemReadRepository
	{
		public BasketItemReadRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
