using App.Application.EventCategories.Queries.GetAllEventCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetAllEventCategoriesQuery());
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while processing the request please try again later");
            }
          
        }
    }
}
