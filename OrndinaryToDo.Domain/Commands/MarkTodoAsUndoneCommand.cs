using System;
using Flunt.Notifications;
using Flunt.Validations;
using OrndinaryToDo.Domain.Commands.Contracts;

namespace OrndinaryToDo.Domain.Commands
{
    public class MarkTodoAsUndoneCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public MarkTodoAsUndoneCommand() { }

        public MarkTodoAsUndoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(User, 6, "User", "Task name must be greater than 6 characters"));
        }
    }
}