﻿using System.ComponentModel.DataAnnotations;

namespace RestApiTetsProject.Dtos
{
	public class PersonReadDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Age { get; set; }
	}
}
