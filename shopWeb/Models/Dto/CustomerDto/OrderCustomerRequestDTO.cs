using System.ComponentModel.DataAnnotations;

namespace shopWeb.Models.Dto.CutomerDto
{
	public class OrderCustomerRequestDTO
	{




		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }



		public string Email { get; set; }

		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }

		[Required(ErrorMessage = "PhoneNumber is required")]
		public int PhoneNumber { get; set; }
		[Required(ErrorMessage = "Total price is required")]
		public decimal OrderTotalPrice { get; set; }

		[Required(ErrorMessage = "Cart info is required")]
		public List<CartItemDTO> CartInfo { get; set; }
	}
}
