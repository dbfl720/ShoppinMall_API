using System.ComponentModel.DataAnnotations;

namespace shopWeb.Models.Dto.CutomerDto
{
	public class LookupCustomerReqeustDTO
	{

		[Required(ErrorMessage = "OrderId is required")]
		public int OrderId { get; set; }

		public string Name { get; set; }

		public int PhoneNumber { get; set; }

	}
}
