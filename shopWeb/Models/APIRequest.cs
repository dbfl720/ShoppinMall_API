using static shopUtility.SD;

namespace shopWeb.Models
{
	public class APIRequest
	{

		public ApiType ApiType { get; set; } = ApiType.GET;

		public string ApiUrl { get; set; }

		public Object Data { get; set; }
	}
}
