using Microsoft.EntityFrameworkCore;
using RestApiTetsProject.Models;

namespace RestApiTetsProject.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
		{
			
		}

		public DbSet<Person> Persons { get; set; }
	}
}
