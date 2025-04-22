using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
	public class BasketItem : BaseEntity
	{
		public int ProductId { get; set; }
		public int BasketId { get; set; }
		public int Quantity { get; set; }

		public Basket Basket { get; set; }
		public Product Product { get; set; }
	}
}
