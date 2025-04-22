using ETicaretAPI.Application.Repositories.Customer;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories.Customer
{
	public class CustomerReadRepository : ReadRepository<Domain.Entities.Customer>, ICustomerReadRepository
	{
		public CustomerReadRepository(ETicaretAPIDbContext context) : base(context)
		{
		}
	}
}
