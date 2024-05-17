﻿namespace Todo.Application.Commands
{
    public class MarkTodoAsDoneCommand : CommandBase
    {
        public MarkTodoAsDoneCommand() { }

        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string? User { get; set; }

        public override void Validate()
        {
        }
    }
}
