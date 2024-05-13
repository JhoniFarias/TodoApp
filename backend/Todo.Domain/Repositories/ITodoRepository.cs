using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todoItem);
        TodoItem GetById(Guid id, string user);
        void Update(TodoItem todoItem);

        IEnumerable<TodoItem> GetAll(string user);       
        IEnumerable<TodoItem> GetAllDone(string user);

        IEnumerable<TodoItem> GetAllUnDone(string user);
        IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done);

    }
}
