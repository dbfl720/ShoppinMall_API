using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using shopAPI.Data;
using shopAPI.Models.Dto.AdminDto;
using shopAPI.Repository.IRepository;

namespace shopAPI.Repository
{
	public class UserRepository : IUserRepository
	{

		private readonly ApplicationDbContext _db;

		private string secretKey;


		public UserRepository(ApplicationDbContext db, IConfiguration configuration)
		{
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}



		public bool IsUniqueUser(string LoginId)
		{
			var user = _db.User.FirstOrDefault(x => x.LoginId == LoginId);
			if (user == null)
			{
				return true;
			}
			return false;
		}




		// Login 
		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.User.FirstOrDefault(u => u.LoginId.ToLower() == loginRequestDTO.LoginId.ToLower()
			&& u.Password == loginRequestDTO.Password);


			if (user == null)
			{
				return new LoginResponseDTO()
				{
					Token = "",
					User = null
				};
			}

			// if user was found generate JWT Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString()),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};



			// generate token 
			var token = tokenHandler.CreateToken(tokenDescriptor);

			LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
			{
				Token = tokenHandler.WriteToken(token),
				User = user,

			};

			return loginResponseDTO;
		}

	}
}
