using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopAPI.Data;
using shopAPI.Models;
using shopAPI.Models.Dto.AdminDto;

namespace shopAPI.Controllers.Admin

{
	// list로 가져올 경우. 
	//[Route("admin/[controller]")]
	[Route("admin/product")]
	[ApiController]
	public class ProductController : ControllerBase
	{

		private readonly ApplicationDbContext _db;

		public ProductController(ApplicationDbContext db)
		{
			_db = db;
		}




		[HttpGet]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProduct()  //여러개 파라미터 받기 
		{
			return Ok(await _db.Product.ToListAsync());
		}





		// 1개 파라미터 가져올 경우. 
		//[HttpGet("{id:int}")]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		//public ActionResult<ProductDTO> GetProduct(int id)  //한개 파라미터 받기 
		//{
		//	if (id == 0)
		//	{
		//		return BadRequest();
		//	}

		//	var productId = _db.Product.FirstOrDefault(u => u.Id == id);
		//	if (productId == null)
		//	{
		//		return NotFound();
		//	}

		//	return Ok(productId);
		//}






		[HttpPost]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductDTO productDTO)
		{


			// Uniqe name
			if (await _db.Product.FirstOrDefaultAsync(u => u.ProductName.ToLower() == productDTO.ProductName.ToLower()) != null)
			{
				ModelState.AddModelError("CustomError", "Product name already exists!");
				return BadRequest(ModelState);
			}

			if (productDTO == null)
			{
				return BadRequest(productDTO);
			}

			if (productDTO.Id > 0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}




			Product model = new Product()
			{
				ProductName = productDTO.ProductName,
				ProductPrice = productDTO.ProductPrice,
				ProductDescription = productDTO.ProductDescription,
				ProductImage = productDTO.ProductImage,
				CreateAt = DateTime.Now, // 생성 시간 설정
				UpdateAt = DateTime.Now  // 업데이트 시간 설정
			};


			await _db.Product.AddAsync(model);
			await _db.SaveChangesAsync();

			//return Ok(productDTO);
			return CreatedAtAction(nameof(CreateProduct), productDTO);

		}







		[HttpDelete("{id:int}", Name = "DeleteProduct")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> DeleteProduct(int id)  // return 타입이 no content일 경우에는 IActionResult 쓰기 
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var product = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);

			if (product == null)
			{
				return NotFound();
			}

			_db.Product.Remove(product);
			await _db.SaveChangesAsync();
			return NoContent();
		}







		[HttpPut("{id:int}", Name = "UpdateProduct")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
		{
			if (productDTO == null || id != productDTO.Id)
			{
				return BadRequest();
			}




			// 데이터베이스에서 기존 제품을 가져옴
			var existingProduct = _db.Product.FirstOrDefault(p => p.Id == id);
			if (existingProduct == null)
			{
				return NotFound();
			}

			// 기존 제품 정보를 새 정보로 업데이트
			existingProduct.ProductName = productDTO.ProductName;
			existingProduct.ProductPrice = productDTO.ProductPrice;
			existingProduct.ProductDescription = productDTO.ProductDescription;
			existingProduct.ProductImage = productDTO.ProductImage;
			existingProduct.UpdateAt = DateTime.Now;

			// 데이터베이스에 변경사항을 저장
			await _db.SaveChangesAsync();


			return NoContent();
		}







		[HttpPatch("{id:int}", Name = "UpdatePartialProduct")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] JsonPatchDocument<ProductDTO> patchDTO)
		{
			if (patchDTO == null || id == 0)
			{
				return BadRequest();
			}

			//var product = _db.Product.AsNoTracking().FirstOrDefault(u => u.Id == id);
			var product = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);


			if (product == null)
			{
				return BadRequest();
			}


			ProductDTO productDTO = new()
			{
				ProductName = product.ProductName,
				ProductPrice = product.ProductPrice,
				ProductDescription = product.ProductDescription,
				ProductImage = product.ProductImage
			};




			patchDTO.ApplyTo(productDTO, ModelState);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// 업데이트 시간 설정
			product.UpdateAt = DateTime.Now;

			// 업데이트된 속성 적용
			product.ProductName = productDTO.ProductName;
			product.ProductPrice = productDTO.ProductPrice;
			product.ProductDescription = productDTO.ProductDescription;
			product.ProductImage = productDTO.ProductImage;

			await _db.SaveChangesAsync();



			return NoContent();

		}
	}
}
