using Microsoft.AspNetCore.Mvc;
using shopAPI.Data;
using shopAPI.Models.Dto.CutomerDto;

namespace shopAPI.Controllers.Customer
{


	// list로 가져올 경우. 
	[Route("customer/product")]
	[ApiController]
	public class ProductCustomerController : ControllerBase
	{

		private readonly ApplicationDbContext _db;

		public ProductCustomerController(ApplicationDbContext db)
		{
			_db = db;
		}




		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<ProductCustomerGetDTO>> GetProduct()  //여러개 파라미터 받기 
		{
			var products = _db.Product.Select(p => new ProductCustomerGetDTO
			{
				Id = p.Id,
				ProductName = p.ProductName,
				ProductPrice = p.ProductPrice,
				ProductDescription = p.ProductDescription,
				ProductImage = p.ProductImage
			}).ToList();

			return Ok(products);
		}





	}

}
