using AOP.Application; 
using AOP.Application.Person;
using AOP.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPersons")]
        public async Task<IActionResult> GetPersons()
        {
            var result = await _mediator.Send(new AddPerson.Query
            {
                persons = new List<Person> 
                {
                    new Person { Id = 1, Name = "Ali" },
                    new Person { Id = 2, Name = "Reza" }
                }
            });

            return StatusCode(200, result.persons);
        }
    }
}
