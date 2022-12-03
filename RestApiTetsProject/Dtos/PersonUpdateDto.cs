using System.ComponentModel.DataAnnotations;

namespace RestApiTetsProject.Dtos
{
    public class PersonUpdateDto
    {
	    [Required(ErrorMessage = "Enter the name")]
	    [MinLength(2, ErrorMessage = "Minimal length of name must be 2 chars")]
	    [MaxLength(50, ErrorMessage = "Maximal length of name mustn't exceed 50 chars")]
		public string Name { get; set; }

		[Required]
		[Range(1, 110, ErrorMessage = "Invalid Age")]
		public int Age { get; set; }
    }
}
