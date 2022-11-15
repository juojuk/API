using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_mokymai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<Person> persons = new List<Person>
            {
                new Person { Id = 1, Name = "Jonas", Surname = "Jonaitis" },
                new Person { Id = 2, Name = "Petras", Surname = "Petraitis" },
                new Person { Id = 3, Name = "Antanas", Surname = "Antanaitis" }
            };


        [HttpGet("asmenys")]
        public List<Person> GetMyPersons()
        {
            return persons;
        }

        [HttpGet("{id}")]
        public Person? GetMyPersonById(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        [HttpGet("pagalvarda/{name}")]
        public Person? GetMyPersonByName(string name)
        {
            return persons.FirstOrDefault(p => p.Name == name);
        }


        [HttpGet("pagalpavarde/{surname}")]
        public Person? GetMyPersonBySurname(string surname)
        {
            return persons.FirstOrDefault(p => p.Surname == surname);
        }

        [HttpGet("pagal")]
        public Person? GetMyPersonByNameAndSurname(string name, string surname)
        {
            return persons.FirstOrDefault(p => p.Name.Contains(name) && p.Surname == surname);
        }

    }
}
