using ETicaretAPI.Application.DTOs.Product;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProduct
{
	public class GetAllProductQueryResponse
	{
		public List<GetAllProductDto> Products { get; set; }
	}
}
