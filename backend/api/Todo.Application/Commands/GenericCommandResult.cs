using Todo.Application.Commands.Contracts;

namespace Todo.Application.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }
        public GenericCommandResult(bool success, string message, object date)
        {
            Success = success;
            Message = message;
            Date = date;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public object Date { get; set; }
    }
}
