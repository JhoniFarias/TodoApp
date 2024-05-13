using Todo.Domain.Validators;

namespace Todo.Domain.Commands
{
    public class CreateTodoCommand : CommandBase
    {
        public CreateTodoCommand(){}
        public CreateTodoCommand(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
            Done = false;
        }

        public string Title { get;  set; }
        public bool Done { get;  set; }
        public DateTime Date { get;  set; }
        public string? User { get;  set; }

        public override void Validate()
        {
            var validator = new CreateTodoItemCommandValidator();
            var validationResult = validator.Validate(this);

            AddNotifications(validationResult);
        }
    }
}
