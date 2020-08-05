using Flunt.Notifications;
using OrndinaryToDo.Domain.Commands;
using OrndinaryToDo.Domain.Commands.Contracts;
using OrndinaryToDo.Domain.Entities;
using OrndinaryToDo.Domain.Handlers.Contracts;
using OrndinaryToDo.Domain.Repositories;

namespace OrndinaryToDo.Domain.Handlers
{
    public class TodoHandler :
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;
        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid) return new CommandResult(false, "Ops, there's something wrong with the defined task!", command.Notifications);

            // Creates a TodoItem
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //Save on DB
            _repository.Create(todo);

            //Notifify application user
            return new CommandResult(true, "Todo sucessfully created!", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(false, "Ops, there's something wrong with the defined task!", command.Notifications);

            //Retrieve a TodoItem (*Reidratação)
            var todo = _repository.GetById(command.Id, command.User);

            //Updates Todo
            todo.UpdateTitle(command.Title);

            //Save on DB
            _repository.Update(todo);

            //Notifify application user
            return new CommandResult(true, "Todo sucessfully Updated!", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(false, "Ops, there's something wrong with the defined task!", command.Notifications);

            //Retrieve a TodoItem (*Reidratação)
            var todo = _repository.GetById(command.Id, command.User);

            //Updates Todo
            todo.MarkAsDone();

            //Save on DB
            _repository.Update(todo);

            //Notifify application user
            return new CommandResult(true, "Todo sucessfully marked as done!", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid) return new CommandResult(false, "Ops, there's something wrong with the defined task!", command.Notifications);

            //Retrieve a TodoItem (*Reidratação)
            var todo = _repository.GetById(command.Id, command.User);

            //Updates Todo
            todo.MarkAsUndone();

            //Save on DB
            _repository.Update(todo);

            //Notifify application user
            return new CommandResult(true, "Todo sucessfully marked as undone!", todo);
        }
    }
}