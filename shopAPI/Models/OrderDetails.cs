using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopAPI.Models
{
	public class OrderDetails
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }


		// orderId에 대한 외래 키
		public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		public Order Order { get; set; }



		// productId에 대한 외래 키
		public int ProductId { get; set; }
		[ForeignKey("ProductId")]
		public Product Product { get; set; }



		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }
	}
}
