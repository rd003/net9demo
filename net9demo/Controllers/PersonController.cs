using Microsoft.AspNetCore.Mvc;
using net9demo.Models;
using net9demo.Repositories;
namespace net9demo.Controllers;

[Route("api/people")]
[ApiController]
public class PersonController(IPersonRepository personRepository,ILogger<PersonController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> People()
    {
        try
        {
            var people = await personRepository.GetPeople();
            return Ok(people);
        }
        catch (Exception ex) {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public IActionResult AddPerson(Person person )
    {
        try
        {
            return CreatedAtAction(nameof(AddPerson),person);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}


