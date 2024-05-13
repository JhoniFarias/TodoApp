using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : 
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUnDoneCommand>
    {
        private readonly ITodoRepository _todoRepository;

        public TodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "erro ao tentar validar o command", command.Notifications);


            var todoItem = new TodoItem(command.Title, command.Date, command.User);

            _todoRepository.Create(todoItem);


            return new GenericCommandResult(true, "Tarefa salva com sucesso", todoItem);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "erro ao tentar validar o command", command.Notifications);


            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "Tarefa atualizada com sucesso", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "erro ao tentar validar o command", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "done", todo);
        }

        public ICommandResult Handle(MarkTodoAsUnDoneCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "erro ao tentar validar o command", command.Notifications);

            var todo = _todoRepository.GetById(command.Id, command.User);
            todo.MarkAsUnDone();

            _todoRepository.Update(todo);

            return new GenericCommandResult(true, "undone", todo);
        }
    }
}
