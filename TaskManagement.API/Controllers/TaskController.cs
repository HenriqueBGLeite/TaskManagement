using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.UseCases.Tasks.Delete;
using TaskManagement.Application.UseCases.Tasks.GetAll;
using TaskManagement.Application.UseCases.Tasks.GetById;
using TaskManagement.Application.UseCases.Tasks.Register;
using TaskManagement.Application.UseCases.Tasks.Update;
using TaskManagement.Communication.Requests;
using TaskManagement.Communication.Responses;

namespace TaskManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTaskJson request)
    {
        var response = new RegisterTaskUseCase().Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = new GetAllTasksUseCase().Execute();
        if(response.Tasks.Any())
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var response = new GetTaskByIdUseCase().Execute(id);

        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        var useCase = new UpdateTaskUseCase();

        useCase.Execute(id, request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var useCase = new DeleteTaskUseCase();

        useCase.Execute(id);

        return NoContent();
    }
}
