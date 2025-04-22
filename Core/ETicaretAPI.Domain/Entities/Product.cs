using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
	public class Product : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }

		public ICollection<Order> Orders { get; set; }
		public ICollection<BasketItem> BasketItems { get; set; }
	}
}
