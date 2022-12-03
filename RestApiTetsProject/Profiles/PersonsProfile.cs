using AutoMapper;
using RestApiTetsProject.Dtos;
using RestApiTetsProject.Models;

namespace RestApiTetsProject.Profiles
{
	public class PersonsProfile : Profile
	{
		public PersonsProfile()
		{
			CreateMap<Person, PersonReadDto>();
			CreateMap<PersonCreateDto, Person>();
			CreateMap<PersonUpdateDto, Person>();
		}
	}
}
