using FluentValidation;
using TaskMangmentSystem.DTOs;

namespace TaskManagementSystem.Validators;
public class TaskValidator : AbstractValidator<TaskDto>
{
    public TaskValidator()
    {
        RuleFor(t => t.Title).NotEmpty().MaximumLength(100);
        RuleFor(t => t.DueDate).GreaterThan(DateTime.Now);
    }
}