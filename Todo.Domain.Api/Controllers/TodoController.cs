using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
   
    public class TodoController : ControllerBase
    {

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
        {
            
            return repository.GetAll("rayancarvalho");
        }

        [Route("")]
        [HttpPost]
        public GeneicCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "rayancarvalho";
            return (GeneicCommandResult)handler.Handle(command);
        }


        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {

            return repository.GetAllDone("rayancarvalho");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone([FromServices] ITodoRepository repository)
        {

            return repository.GetAllDone("rayancarvalho");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {

            return repository.GetByPeriod("rayancarvalho", System.DateTime.Now.Date, true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForToday([FromServices] ITodoRepository repository)
        {

            return repository.GetByPeriod("rayancarvalho", System.DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {

            return repository.GetByPeriod("rayancarvalho", System.DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUnDoneForTomorrow([FromServices] ITodoRepository repository)
        {

            return repository.GetByPeriod("rayancarvalho", System.DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPut]
        public GeneicCommandResult Update([FromBody]UpdateTodoCommand command,[FromServices] TodoHandler handler)
        {

            command.User = "rayancarvalho";
            return (GeneicCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GeneicCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "rayancarvalho";
            return (GeneicCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GeneicCommandResult MarkAsUnDone([FromBody] MarkAsUnDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "rayancarvalho";
            return (GeneicCommandResult)handler.Handle(command);
        }


    }
}
