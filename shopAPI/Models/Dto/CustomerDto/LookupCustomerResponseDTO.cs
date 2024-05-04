namespace shopAPI.Models.Dto.CutomerDto
{
	public class LookupCustomerResponseDTO
	{


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
