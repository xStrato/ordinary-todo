using OrndinaryToDo.Domain.Commands.Contracts;

namespace OrndinaryToDo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}