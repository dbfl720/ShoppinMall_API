using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopAPI.Models
{
	public class Product
	{


		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string ProductName { get; set; }

		public decimal ProductPrice { get; set; }
		public string? ProductDescription { get; set; }

		public string? ProductImage { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }


	}
}
