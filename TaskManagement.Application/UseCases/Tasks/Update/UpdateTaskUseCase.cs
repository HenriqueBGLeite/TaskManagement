using TaskManagement.Application.UseCases.Tasks.SharedValidator;
using TaskManagement.Communication.Excepetions;
using TaskManagement.Communication.Requests;
using TaskManagement.Infrastructure;

namespace TaskManagement.Application.UseCases.Tasks.Update;

public class UpdateTaskUseCase
{
    public void Execute(Guid id, RequestTaskJson request)
    {
        var dbContext = new TaskManagementDbContext();

        var entity = dbContext.Tasks.FirstOrDefault(task => task.Id.Equals(id));
        if (entity is null)
            throw new NotFoundException("Tarefa não encontrada.");

        Validate(request);

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Priority = request.Priority;
        entity.DueDate = request.DueDate;
        entity.Status = request.Status;

        dbContext.Tasks.Update(entity);
        dbContext.SaveChanges();
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
