using FluentValidation;
using TaskMangmentSystem.DTOs;

namespace TaskManagementSystem.Validators;
public class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(u => u.UserName).NotEmpty().MaximumLength(50);
        RuleFor(u => u.Email).NotEmpty().EmailAddress();
    }
}