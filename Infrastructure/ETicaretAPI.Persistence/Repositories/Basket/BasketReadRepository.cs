using ETicaretAPI.Application.Repositories.Basket;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories.Basket
{
	public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
	{
		public BasketReadRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
