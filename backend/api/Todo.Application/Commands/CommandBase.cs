using Todo.Application.Commands.Contracts;
using Todo.Application.Notifications;

namespace Todo.Application.Commands
{
    public abstract class CommandBase : Notifiable, ICommand
    {
        public abstract void Validate();
    }
}
