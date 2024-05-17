namespace Todo.Application.Commands
{
    public class UpdateTodoCommand : CommandBase
    {
        public UpdateTodoCommand() { }
        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public override void Validate()
        {
        }
    }
}
