using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    public class TodoItemTests
    {
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido() 
        {
            var todo = new TodoItem("teste", DateTime.Now, "jhonifarias.developer@gmail.com");
            Assert.False(todo.Done);
        }
    }
}
