using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        private readonly TodoHandler _todoHandler;

        public TodoController(ITodoRepository todoRepository, TodoHandler todoHandler)
        {
            _todoRepository = todoRepository;
            _todoHandler = todoHandler;
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command)
        {
            command.User = GetUserLogged();
            var result = (GenericCommandResult)_todoHandler.Handle(command);
            return result;
        }

        [HttpPut]
        public GenericCommandResult Update([FromBody]UpdateTodoCommand command)
        {
            command.User = GetUserLogged();
            var result = (GenericCommandResult)_todoHandler.Handle(command);
            return result;
        }

        [Route("markAsDone")]
        [HttpPost]
        public GenericCommandResult MaskAsDone([FromBody]MarkTodoAsDoneCommand command)
        {
            command.User = GetUserLogged();
            var result = (GenericCommandResult)_todoHandler.Handle(command);
            return result;
        }

        [Route("markAsUndone")]
        [HttpPost]
        public GenericCommandResult MaskAsUnDone([FromBody]MarkTodoAsUnDoneCommand command)
        {
            command.User = GetUserLogged();
            var result = (GenericCommandResult)_todoHandler.Handle(command);
            return result;
        }


        [Route("getAll")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
           return _todoRepository.GetAll(GetUserLogged());
        }

        [Route("getAllDone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone()
        {
            return _todoRepository.GetAllDone(GetUserLogged());
        }

        [Route("getAllUnDone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone()
        {
            return _todoRepository.GetAllUnDone(GetUserLogged());
        }

        [Route("today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetTodayTodos()
        {
            
            return _todoRepository.GetByPeriod(GetUserLogged(), DateTime.Now, false);
        }

        [Route("tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetTomorrowTodos()
        {

            return _todoRepository.GetByPeriod(GetUserLogged(), DateTime.Now.AddDays(1), false);
        }

        private string GetUserLogged()
        {
            return User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value ?? "";
        }
    }
}
