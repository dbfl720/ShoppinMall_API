using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopAPI.Data;
using shopAPI.Models.Dto.CutomerDto;

namespace shopAPI.Controllers.Customer
{


	[Route("customer/order")]
	[ApiController]
	public class LookupCustomerController : ControllerBase
	{

		private readonly ApplicationDbContext _db;

		public LookupCustomerController(ApplicationDbContext db)
		{
			_db = db;
		}





		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<string>> Lookup([FromBody] LookupCustomerReqeustDTO lookupRequestDTO)
		{
			if (lookupRequestDTO == null)
			{
				return BadRequest("Order Id is required.");
			}



			// Search for the order in the database
			var orderQuery = from order in _db.Order
							 join orderDetail in _db.OrderDetails on order.Id equals orderDetail.OrderId
							 where order.Id == lookupRequestDTO.OrderId
							 select new
							 {
								 Order = order,
								 OrderDetail = orderDetail
							 };

			var orderData = await orderQuery.FirstOrDefaultAsync();

			if (orderData == null)
			{
				return NotFound("Not Found");
			}

			// Order found, prepare the response DTO
			var responseDto = new LookupCustomerResponseDTO
			{
				OrderStatus = orderData.Order.OrderStatus,
				Name = orderData.Order.Name,
				Email = orderData.Order.Email,
				Address = orderData.Order.Address,
				PhoneNumber = orderData.Order.PhoneNumber,
				OrderTotalPrice = orderData.Order.OrderTotalPrice,
				CreateAt = orderData.Order.CreateAt,
				UpdateAt = orderData.Order.UpdateAt,
				ProductInfo = orderQuery.Select(od => new LookupItemDTO
				{
					ProductName = od.OrderDetail.Product.ProductName,
					UnitPrice = od.OrderDetail.UnitPrice,
					Quantity = od.OrderDetail.Quantity,
					TotalPrice = od.OrderDetail.UnitPrice * od.OrderDetail.Quantity
				}).ToList()
			};

			return Ok(responseDto);

		}
	}
}
