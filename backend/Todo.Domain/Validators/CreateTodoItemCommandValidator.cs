using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;

namespace Todo.Domain.Validators
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
