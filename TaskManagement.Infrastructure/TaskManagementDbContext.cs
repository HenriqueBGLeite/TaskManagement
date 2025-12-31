using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure;

public class TaskManagementDbContext : DbContext
{
    public DbSet<Domain.Entities.Task> Tasks { get; set; }

    public TaskManagementDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Projetos\\Pessoal\\Cursos Rocketseat\\TaskManagementDB.db");
    }
}
