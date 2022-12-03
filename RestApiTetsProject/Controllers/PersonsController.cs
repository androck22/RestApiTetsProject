using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApiTetsProject.Data;
using RestApiTetsProject.Dtos;
using RestApiTetsProject.Models;

namespace RestApiTetsProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly IPersonRepo _repository;
		private readonly IMapper _mapper;

		public PersonsController(IPersonRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>
		/// View a list of all persons
		/// </summary>
		/// <response code="200">View a list of all persons</response>
		[HttpGet]
		public ActionResult<IEnumerable<PersonReadDto>> GetPersons()
		{
			Console.WriteLine("--> Getting Platforms...");

			var personItem = _repository.GetAllPersons();

			return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(personItem));
		}

		/// <summary>
		/// View a range of persons
		/// </summary>
		/// <response code="200">View a range of persons</response>
		[HttpGet("{startId}-{endId}")]
		public ActionResult<IEnumerable<PersonReadDto>> GetRangePersons(int startId, int endId)
		{
			Console.WriteLine("--> Getting Range Platforms...");

			var personItem = _repository.GetRangePersons(startId, endId);

			if (personItem != null)
			{
				return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(personItem));
			}

			return NotFound();
		}

		/// <summary>
		/// View person by id
		/// </summary>
		/// <response code="200">View person by id</response>
		[HttpGet("{id}", Name = "GetPersonById")]
		public ActionResult<PersonReadDto> GetPersonById(int id)
		{
			var personItem = _repository.GetPersonById(id);
			if (personItem != null)
			{
				return Ok(_mapper.Map<PersonReadDto>(personItem));
			}

			return NotFound();
		}

		/// <summary>
		/// Creates a person
		/// </summary>
		/// <response code="200">Creates a person</response>
		[HttpPost]
		public ActionResult<PersonReadDto> CreatePerson([FromBody] PersonCreateDto personCreateDto)
		{
			var personModel = _mapper.Map<Person>(personCreateDto);
			_repository.CreatePerson(personModel);
			_repository.SaveChanges();

			var personReadDto = _mapper.Map<PersonReadDto>(personModel);

			return CreatedAtRoute(nameof(GetPersonById), new { Id = personReadDto.Id }, $"Person {personReadDto.Name} was created!");
		}

		/// <summary>
		/// Updating information about a person
		/// </summary>
		/// <response code="200">Updating information about a person</response>
		[HttpPatch("{id}")]
		public ActionResult<PersonReadDto> UpdatePerson(int id, [FromBody] PersonUpdateDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var person = _repository.GetPersonById(id);
			if (person == null)
			{
				return NotFound();
			}

			_repository.UpdatePerson(person, model);

			return StatusCode(200, $"Information about person {person.Name} updated!");
		}

		/// <summary>
		/// Deletes a person
		/// </summary>
		/// <response code="200">Deletes a person</response>
		[HttpDelete("{id}")]
		public ActionResult DeletePerson(int id)
		{
			var personItem = _repository.GetPersonById(id);
			if (personItem == null)
			{
				return NotFound();
			}

			_repository.DeletePerson(id);
			_repository.SaveChanges();

			return Ok(new {Message = $"Person {personItem.Name} was successfully deleted!"});
		}
	}
}
