using Microsoft.EntityFrameworkCore;
using RestApiTetsProject.Dtos;
using RestApiTetsProject.Models;

namespace RestApiTetsProject.Data
{
	public class PersonRepo : IPersonRepo
	{
		private readonly AppDbContext _context;

		public PersonRepo(AppDbContext context)
		{
			_context = context;
		}
		public IEnumerable<Person> GetAllPersons()
		{
			return _context.Persons.ToList();
		}

		public IEnumerable<Person> GetRangePersons(int startId, int endId)
		{
			if (endId < startId)
			{
				int temp = 0;
				temp = startId;
				startId = endId;
				endId = temp;
			}
			return _context.Persons.Where(p => p.Id >= startId && p.Id <= endId).ToList();
		}

		public Person GetPersonById(int id)
		{
			return _context.Persons.FirstOrDefault(p => p.Id == id);
		}

		public void CreatePerson(Person person)
		{
			if (person == null)
			{
				throw new ArgumentNullException(nameof(person));
			}

			_context.Persons.Add(person);
		}

		public void UpdatePerson(Person person, PersonUpdateDto queryDto)
		{
			if(!string.IsNullOrEmpty(queryDto.Name) && queryDto.Name != "string")
				person.Name = queryDto.Name;
			if(queryDto.Age != 0)
				person.Age = queryDto.Age;

			var entry = _context.Entry(person);
			if (entry.State == EntityState.Detached)
				_context.Persons.Update(person);

			_context.SaveChanges();
		}
		
		public void DeletePerson(int id)
		{
			var person = _context.Persons.FirstOrDefault(p => p.Id == id);

			_context.Persons.Remove(person);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}
