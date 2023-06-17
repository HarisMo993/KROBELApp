using KROBEL.Domain.Models;
using KROBEL.Service.PersonService;
using Microsoft.AspNetCore.Mvc;

namespace KROBEL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet(nameof(GetPerson))]
        public IActionResult GetPerson(int id) 
        {
            var result = _personService.GetPerson(id);
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetAllPersons))]
        public IActionResult GetAllPersons() 
        {
            var result = _personService.GetAllPersons();
            if (result is not null)
            {
                return Ok(result);
            }
            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertPerson))]
        public IActionResult InsertPerson(Person person)
        {
            _personService.InsertPerson(person);
            return Ok(new { message = "Data inserted" });

        }

        [HttpPut(nameof(UpdatePerson))]
        public IActionResult UpdatePerson(Person person)
        {
            _personService.UpdatePerson(person);
            return Ok(new { message = "Updation done" });
        }

        [HttpDelete(nameof(DeletePerson)+"/{id}")]
        public IActionResult DeletePerson(int id)
        {
            _personService.DeletePerson(id);
            return Ok(new { message = "Data deleted" });
        }
    }
}
