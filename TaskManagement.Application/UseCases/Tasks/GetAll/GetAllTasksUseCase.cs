using TaskManagement.Communication.Responses;
using TaskManagement.Infrastructure;

namespace TaskManagement.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTasksJson Execute()
    {
        var dbContext = new TaskManagementDbContext();

        var tasks = dbContext.Tasks.ToList();

        return new ResponseAllTasksJson
        {
            Tasks = [.. tasks.Select(task => new ResponseShortTaskJson {
                Id = task.Id,
                Name = task.Name,
            })]
        };
    }
}
