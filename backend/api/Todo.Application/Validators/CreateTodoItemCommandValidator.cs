using FluentValidation;
using Todo.Application.Commands;

namespace Todo.Application.Validators
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotNull()
                .WithMessage("o titulo não pode ser nullo")
                .NotEmpty()
                .WithMessage("o titulo não pode ser vazio")
                .MinimumLength(3)
                .WithMessage("o titulo precisa ter pelo menos 3 caracteres");


        }
    }
}
