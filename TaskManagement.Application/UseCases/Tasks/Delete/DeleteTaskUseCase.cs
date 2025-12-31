using TaskManagement.Communication.Excepetions;
using TaskManagement.Infrastructure;

namespace TaskManagement.Application.UseCases.Tasks.Delete;

public class DeleteTaskUseCase
{
    public void Execute(Guid id)
    {
        var dbContext = new TaskManagementDbContext();

        var entity = dbContext.Tasks.FirstOrDefault(task => task.Id.Equals(id));
        if (entity is null)
            throw new NotFoundException("Tarefa não encontrada.");

        dbContext.Tasks.Remove(entity);
        dbContext.SaveChanges();
    }
}
