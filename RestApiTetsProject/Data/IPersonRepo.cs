using RestApiTetsProject.Dtos;
using RestApiTetsProject.Models;

namespace RestApiTetsProject.Data
{
	public interface IPersonRepo
	{
		IEnumerable<Person> GetAllPersons();
		IEnumerable<Person> GetRangePersons(int startId, int endId);
		Person GetPersonById(int id);
		void CreatePerson(Person person);
		void UpdatePerson(Person person, PersonUpdateDto queryDto);
		public void DeletePerson(int id);
		bool SaveChanges();
	}
}
