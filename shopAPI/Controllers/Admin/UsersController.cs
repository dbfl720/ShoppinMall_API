using System.Net;
using Microsoft.AspNetCore.Mvc;
using shopAPI.Models;
using shopAPI.Models.Dto.AdminDto;
using shopAPI.Repository.IRepository;

namespace shopAPI.Controllers.Admin
{



	[Route("admin/login")]
	[ApiController]
	public class UsersController : Controller
	{

		// 1.Dependency injection -> 2. program.cs에서 코드 넣어야됨. 
		private readonly IUserRepository _userRepo;
		protected APIResponse _response;
		public UsersController(IUserRepository userRepo)
		{
			_userRepo = userRepo;
			this._response = new();
		}




		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
		{

			var loginResponse = await _userRepo.Login(model);
			if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("Admin ID is incorrect");
				return BadRequest(_response);
			}
			_response.StatusCode = HttpStatusCode.OK;
			_response.IsSuccess = true;
			_response.Result = loginResponse;
			return Ok(_response);
		}
	}
}
