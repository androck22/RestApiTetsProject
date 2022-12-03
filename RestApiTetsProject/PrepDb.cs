using RestApiTetsProject.Data;
using RestApiTetsProject.Models;

namespace RestApiTetsProject
{
	public static class PrepDb
	{
		public static void PrepPopulation(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
			}
		}

		private static void SeedData(AppDbContext context)
		{
			if (!context.Persons.Any())
			{
				Console.WriteLine("--> Seeding Data...");

				context.Persons.AddRange(
					new Person() {Name = "Igor", Age = 26},
					new Person() { Name = "Bob", Age = 33 },
					new Person() { Name = "William", Age = 34 },
					new Person() { Name = "Mike", Age = 32 },
					new Person() { Name = "David", Age = 25 },
					new Person() { Name = "Michael", Age = 22 },
					new Person() { Name = "Robert", Age = 31 },
					new Person() { Name = "James", Age = 23 },
					new Person() { Name = "Thomas", Age = 26 },
					new Person() { Name = "Daniel", Age = 30 },
					new Person() { Name = "Mark", Age = 29 },
					new Person() { Name = "Steven", Age = 27 }
				);

				context.SaveChanges();
			}
			else
			{
				Console.WriteLine("--> We already have data");
			}
		}
	}
}
