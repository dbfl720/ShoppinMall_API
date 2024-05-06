using shopAPI.Models;

namespace shopWeb.Models.Dto.AdminDto
{
	public class LoginResponseDTO
	{

		public User User { get; set; }

		public string Token { get; set; }


	}
}
