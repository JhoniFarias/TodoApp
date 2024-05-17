
using FluentValidation;

namespace Todo.Application.Commands.Contracts
{
    public interface ICommand
    {
        public void Validate();
    }
}
