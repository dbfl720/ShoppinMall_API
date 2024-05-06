using shopWeb.Models.Dto.CutomerDto;

namespace shopWeb.Models.Dto.AdminDto
{
	public class OrderManagementResponseDTO
	{

		public int OrderId { get; set; }
		public string OrderStatus { get; set; }


		public string Name { get; set; }



		public string Email { get; set; }


		public string Address { get; set; }


		public int PhoneNumber { get; set; }

		public decimal OrderTotalPrice { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }


		public List<LookupItemDTO> ProductInfo { get; set; }


	}
}
