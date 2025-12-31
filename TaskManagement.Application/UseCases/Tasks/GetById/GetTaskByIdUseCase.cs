using TaskManagement.Communication.Excepetions;
using TaskManagement.Communication.Responses;
using TaskManagement.Infrastructure;

namespace TaskManagement.Application.UseCases.Tasks.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTaskJson Execute(Guid id)
    {
        var dbContext = new TaskManagementDbContext();

        var entity = dbContext.Tasks.FirstOrDefault(task => task.Id.Equals(id));
        if (entity is null)
            throw new NotFoundException("Tarefa não encontrada.");

        return new ResponseTaskJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Priority = entity.Priority,
            DueDate = entity.DueDate,
            Status = entity.Status
        };
    }
}
