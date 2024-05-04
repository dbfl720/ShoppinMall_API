using System.ComponentModel.DataAnnotations;


namespace shopAPI.Models.Dto.AdminDto
{
	public class ProductDTO
	{

		public int Id { get; set; }
		[Required(ErrorMessage = "Product Name is required")]
		public string ProductName { get; set; }

		[Required(ErrorMessage = "Unit Price is required")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be a positive number")]
		public decimal ProductPrice { get; set; }
		public string? ProductDescription { get; set; }

		public string? ProductImage { get; set; }

		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }


	}
}
