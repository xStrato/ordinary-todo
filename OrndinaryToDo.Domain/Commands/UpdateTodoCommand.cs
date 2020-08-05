using System;
using Flunt.Notifications;
using Flunt.Validations;
using OrndinaryToDo.Domain.Commands.Contracts;

namespace OrndinaryToDo.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public UpdateTodoCommand() { }
        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }
        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Title, 3, "Title", "Task name must be greater than 3 characters")
            .HasMinLen(User, 6, "User", "User name must be greater than 6 characters"));
        }
    }
}