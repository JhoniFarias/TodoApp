using Todo.Application.Commands;

namespace Todo.Application.Tests.CommandTests
{
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "admin");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("teste", DateTime.Now, "admin");

        [Fact]
        public void Dado_um_commando_invalido() 
        {
            _invalidCommand.Validate();
            Assert.False(_invalidCommand.IsValid);
        }

        [Fact]
        public void Dado_um_commando_valido()
        {
            _validCommand.Validate();
            Assert.True(_validCommand.IsValid);
        }
    }
}
