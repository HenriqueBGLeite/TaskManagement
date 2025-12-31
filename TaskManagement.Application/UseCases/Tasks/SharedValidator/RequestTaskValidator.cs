using FluentValidation;
using TaskManagement.Communication.Requests;

namespace TaskManagement.Application.UseCases.Tasks.SharedValidator;

public class RequestTaskValidator : AbstractValidator<RequestTaskJson>
{
    public RequestTaskValidator()
    {
        RuleFor(task => task.Name)
            .NotEmpty().WithMessage("O nome da tarefa não pode ser nulo.")
            .MaximumLength(100);
        RuleFor(task => task.Description)
            .MaximumLength(500);
        RuleFor(task => task.Priority)
            .IsInEnum().WithMessage("Prioridade não aceita no sistema.");
        RuleFor(task => task.DueDate)
            .Must(date => date.Date > DateTime.Today).WithMessage("Somente serão aceitas, datas futuras para o cadastro da tarefa.");
        RuleFor(task => task.Status)
            .IsInEnum().WithMessage("Status não aceito no sistema.");
    }
}
