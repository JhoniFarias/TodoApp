using Todo.Application.Commands;

namespace Todo.Application.Tests.HandlerTests
{
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "admin");
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("teste", DateTime.Now, "admin");


        [Fact]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            var handler = new TodoHandler(new FakeTodoRepository());
            var commandResult = (GenericCommandResult)handler.Handle(_invalidCommand);
            
            Assert.False(commandResult.Success);
        }

        [Fact]
        public void DadoUmComandoValidoDeveCriarATarefa()
        {
            var handler = new TodoHandler(new FakeTodoRepository());
            GenericCommandResult commandResult = (GenericCommandResult)handler.Handle(_validCommand);

            Assert.True(commandResult.Success);
        }
    }
}
