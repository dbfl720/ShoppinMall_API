using AutoMapper;
using shopAPI.Models;
using shopAPI.Models.Dto.AdminDto;

namespace shopAPI
{
	public class MappingConfig : Profile
	{

		public MappingConfig()
		{
			CreateMap<Product, ProductDTO>().ReverseMap();

		}
	}
}
