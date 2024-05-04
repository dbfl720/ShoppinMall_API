using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopAPI.Models
{
	public class User
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string LoginId { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public DateTime CreateAt { get; set; }
		public DateTime UpdateAt { get; set; }


	}
}
