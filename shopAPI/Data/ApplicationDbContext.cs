using Microsoft.EntityFrameworkCore;
using shopAPI.Models;

namespace shopAPI.Data
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Product { get; set; }

		public DbSet<User> User { get; set; }



		public DbSet<Order> Order { get; set; }

		public DbSet<OrderDetails> OrderDetails { get; set; }









		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(

				new Product
				{
					Id = 1,
					ProductName = "yuri",
					ProductPrice = 1000,
					ProductDescription = "haha",
					ProductImage = "image",
					CreateAt = DateTime.Now,
					UpdateAt = DateTime.Now
				},
				new Product
				{
					Id = 2,
					ProductName = "second",
					ProductPrice = 2000,
					ProductDescription = "haha",
					ProductImage = "image",
					CreateAt = DateTime.Now,
					UpdateAt = DateTime.Now
				},
				new Product
				{
					Id = 3,
					ProductName = "third",
					ProductPrice = 3000,
					ProductDescription = "haha",
					ProductImage = "image",
					CreateAt = DateTime.Now,
					UpdateAt = DateTime.Now
				}


				);



			modelBuilder.Entity<User>().HasData(

			new User
			{
				Id = 1,
				LoginId = "admin",
				Password = "admin",
				Role = "admin",
				CreateAt = DateTime.Now,
				UpdateAt = DateTime.Now
			});


		}
	}
}
