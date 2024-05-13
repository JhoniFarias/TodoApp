using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
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
