using Microsoft.AspNetCore.Mvc;
using shopAPI.Data;
using shopAPI.Models;
using shopAPI.Models.Dto.CutomerDto;

namespace shopAPI.Controllers.Customer
{


	[Route("customer/checkout")]
	[ApiController]
	public class OrderCustomerController : ControllerBase
	{

		private readonly ApplicationDbContext _db;

		public OrderCustomerController(ApplicationDbContext db)
		{
			_db = db;
		}






		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<string> Checkout([FromBody] OrderCustomerRequestDTO orderRequestDTO)
		{
			if (orderRequestDTO == null)
			{
				return BadRequest("Order data is required.");
			}



			// Validate order details
			if (string.IsNullOrWhiteSpace(orderRequestDTO.Name) || string.IsNullOrWhiteSpace(orderRequestDTO.Address) ||
				orderRequestDTO.CartInfo == null || !orderRequestDTO.CartInfo.Any())
			{
				return BadRequest("Invalid order data.");
			}



			// Perform order processing
			try
			{


				// Create order entity
				var order = new Order
				{

					OrderStatus = "open",
					Name = orderRequestDTO.Name,
					Email = orderRequestDTO.Email,
					Address = orderRequestDTO.Address,
					PhoneNumber = orderRequestDTO.PhoneNumber,
					OrderTotalPrice = orderRequestDTO.OrderTotalPrice,
					CreateAt = DateTime.Now,
					UpdateAt = DateTime.Now
				};

				// Add order to database
				_db.Order.Add(order);
				_db.SaveChanges();


				// Save order details
				foreach (var item in orderRequestDTO.CartInfo)
				{
					var orderDetail = new OrderDetails
					{
						OrderId = order.Id,
						ProductId = item.ProductId,
						Quantity = item.Quantity,
						UnitPrice = item.UnitPrice,
						CreateAt = DateTime.Now,
						UpdateAt = DateTime.Now
					};

					_db.OrderDetails.Add(orderDetail);
				}

				_db.SaveChanges();


				// Return success message with order code
				return Ok($"Order submitted successfully. Order Code: {order.Id}");
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error occurred while processing the order: {ex.Message}");
			}
		}






	}
}
