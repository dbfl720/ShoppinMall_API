using shopAPI.Models.Dto.AdminDto;

namespace shopAPI.Repository.IRepository
{
	public interface IUserRepository
	{

		bool IsUniqueUser(string LoginId);


		// Task<LoginResponseDTO> 이 부분은 리턴타임.
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
	}
}
