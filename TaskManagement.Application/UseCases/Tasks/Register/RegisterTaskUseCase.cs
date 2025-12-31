using TaskManagement.Application.UseCases.Tasks.SharedValidator;
using TaskManagement.Communication.Excepetions;
using TaskManagement.Communication.Requests;
using TaskManagement.Communication.Responses;
using TaskManagement.Infrastructure;

namespace TaskManagement.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    public ResponseShortTaskJson Execute(RequestTaskJson request)
    {
        var dbContext = new TaskManagementDbContext();

        Validate(request);

        var entity = new Domain.Entities.Task
        {
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = request.Status
        };

        dbContext.Tasks.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortTaskJson
        {
            Id = entity.Id,
            Name = request.Name
        };
    }

    private void Validate(RequestTaskJson request)
    {
        var validator = new RequestTaskValidator();

        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
