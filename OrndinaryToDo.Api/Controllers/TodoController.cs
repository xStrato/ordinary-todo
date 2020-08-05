using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrndinaryToDo.Domain.Commands;
using OrndinaryToDo.Domain.Entities;
using OrndinaryToDo.Domain.Handlers;
using OrndinaryToDo.Domain.Repositories;

namespace OrndinaryToDo.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllTasks([FromServices] ITodoRepository repository)
        {
            return repository.GetAllTasks("xStrato");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("xStrato");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone([FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone("xStrato");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("xStrato", DateTime.Now, true);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("xStrato", DateTime.Now.Date.AddDays(1), true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("xStrato", DateTime.Now, false);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow([FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod("xStrato", DateTime.Now.Date.AddDays(1), false);
        }

        [Route("")]
        [HttpPost]
        //Model Binding
        public CommandResult Create([FromBody] CreateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "xStrato";
            return (CommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        //Model Binding
        public CommandResult Update([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "xStrato";
            return (CommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        //Model Binding
        public CommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "xStrato";
            return (CommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        //Model Binding
        public CommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command, [FromServices] TodoHandler handler)
        {
            command.User = "xStrato";
            return (CommandResult)handler.Handle(command);
        }
    }
}