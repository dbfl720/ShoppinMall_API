using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopAPI.Models.Dto.AdminDto
{
	public class OrderPostDTO
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string OrderStatus { get; set; }

		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }


		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }

		[Required(ErrorMessage = "Phone Number is required")]
		[RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Invalid Phone Number")]
		public int PhoneNumber { get; set; }

		public decimal OrderTotalPrice { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }
	}
}
