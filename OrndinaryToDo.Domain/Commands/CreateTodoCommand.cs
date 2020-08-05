using System;
using Flunt.Notifications;
using Flunt.Validations;
using OrndinaryToDo.Domain.Commands.Contracts;

namespace OrndinaryToDo.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public string Title { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }
        public CreateTodoCommand() { }
        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            Date = date;
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