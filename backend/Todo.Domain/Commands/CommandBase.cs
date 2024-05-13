using FluentValidation;
using FluentValidation.Results;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Notifications;

namespace Todo.Domain.Commands
{
    public abstract class CommandBase : Notifiable, ICommand
    {
        public abstract void Validate();
    }
}
