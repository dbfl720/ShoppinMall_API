namespace shopWeb.Models.Dto.CutomerDto
{
	public class LookupItemDTO
	{
		public string ProductName { get; set; }

		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }


		public decimal TotalPrice { get; set; }
	}
}
