using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using net9demo.Models;

namespace net9demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IValidator<Category> _validator;

        public CategoriesController(IValidator<Category> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var validationResult = await _validator.ValidateAsync(category);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return UnprocessableEntity(ModelState);
            }
            return StatusCode(201,category);
        }

    }
}
