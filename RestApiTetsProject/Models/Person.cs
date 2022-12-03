using System.ComponentModel.DataAnnotations;

namespace RestApiTetsProject.Models
{
	public class Person
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public int Age { get; set; }
	}
}
