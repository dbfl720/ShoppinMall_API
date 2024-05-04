using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopAPI.Models
{
	public class Order
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string OrderStatus { get; set; }


		public string Name { get; set; }



		public string? Email { get; set; }


		public string Address { get; set; }


		public int PhoneNumber { get; set; }

		public decimal OrderTotalPrice { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }

	}
}
