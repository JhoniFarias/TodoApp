using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Commands
{
    public class MarkTodoAsUnDoneCommand : CommandBase
    {
        public MarkTodoAsUnDoneCommand() { }

        public MarkTodoAsUnDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public override void Validate()
        {
        }
    }
}
