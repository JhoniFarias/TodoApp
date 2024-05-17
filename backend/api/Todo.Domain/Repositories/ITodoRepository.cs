using Todo.Domain.Entities;

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
