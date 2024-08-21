using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using net9demo.Models;
using net9demo.Repositories;
namespace net9demo.Controllers;

[Route("api/people")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IValidator<Person> _validator;
    private readonly IPersonRepository personRepository;
    private readonly ILogger<PersonController> logger;

    public PersonController(IValidator<Person> validator, IPersonRepository personRepository, ILogger<PersonController> logger)
    {
        _validator = validator;
        this.personRepository = personRepository;
        this.logger = logger;
    }

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
    public async Task<IActionResult> AddPerson(Person person )
    {
        var personValidator = await _validator.ValidateAsync(person);
        if (!personValidator.IsValid)
        {
            personValidator.AddToModelState(ModelState);
            return UnprocessableEntity(ModelState);
        }

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


