using System;
using OrndinaryToDo.Domain.Entities;

namespace OrndinaryToDo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
        TodoItem GetById(Guid id, string user);
    }
}