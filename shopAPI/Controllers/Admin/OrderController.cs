using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopAPI.Data;
using shopAPI.Models.Dto.AdminDto;
using shopAPI.Models.Dto.CutomerDto;

namespace shopAPI.Controllers.Admin
{


	[Route("admin/order")]
	[ApiController]
	public class OrderController : ControllerBase
	{

		private readonly ApplicationDbContext _db;

		public OrderController(ApplicationDbContext db)
		{
			_db = db;
		}






		// Order Management 
		[HttpGet]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<IEnumerable<OrderGetDTO>>> GetOrder()  //여러개 파라미터 받기 
		{
			return Ok(await _db.Order.ToListAsync());
		}








		[HttpPost]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<string>> ViewOrders([FromBody] LookupCustomerReqeustDTO lookupRequestDTO)
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
			var responseDto = new OrderManagementResponseDTO
			{
				OrderId = orderData.Order.Id,
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














		[HttpPatch("{id:int}", Name = "UpdatePartialOrderStatus")]
		[Authorize(Roles = "admin")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] JsonPatchDocument<OrderPatchRequestDTO> patchDTO)
		{
			if (patchDTO == null || id == 0)
			{
				return BadRequest();
			}




			var order = await _db.Order.FirstOrDefaultAsync(o => o.Id == id);

			if (order == null)
			{
				return NotFound();
			}



			OrderPatchRequestDTO orderPatchRequestDTO = new()
			{
				Id = order.Id,
				OrderStatus = order.OrderStatus
			};



			patchDTO.ApplyTo(orderPatchRequestDTO, ModelState);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}




			// Orders that have been closed cannot be changed to Cancel.
			if (order.OrderStatus.Equals("closed", StringComparison.OrdinalIgnoreCase) && orderPatchRequestDTO.OrderStatus.Equals("cancel", StringComparison.OrdinalIgnoreCase))
			{
				ModelState.AddModelError("OrderStatus", "Cannot change status of closed order to canceld.");
				return BadRequest(ModelState);
			}



			// 업데이트된 속성 적용
			order.OrderStatus = orderPatchRequestDTO.OrderStatus;


			// db저장 
			await _db.SaveChangesAsync();


			return NoContent();

		}
	}
}
