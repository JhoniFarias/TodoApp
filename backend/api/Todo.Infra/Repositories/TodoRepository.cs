using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.DataContexts;

namespace Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todoItem)
        {
            _context.Todos.Add(todoItem);
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _context.Todos.Where(TodoQueries.GetAll(user)).AsNoTracking().ToList();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos.Where(TodoQueries.GetAllDone(user)).AsNoTracking().ToList();
        }

        public IEnumerable<TodoItem> GetAllUnDone(string user)
        {
            return _context.Todos.Where(TodoQueries.GetAllUnDone(user)).AsNoTracking().ToList();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context.Todos.FirstOrDefault(todo => todo.Id == id && todo.User == user);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos.Where(TodoQueries.GetByPeriod(user,date,done)).AsNoTracking().ToList();
        }

        public void Update(TodoItem todoItem)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            _context.SaveChanges();
        }

        

    
    }
}
