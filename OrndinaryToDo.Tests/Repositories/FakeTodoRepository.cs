using System;
using OrndinaryToDo.Domain.Entities;
using OrndinaryToDo.Domain.Repositories;

namespace OrndinaryToDo.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("", "", DateTime.Now);
        }

        public void Update(TodoItem todo)
        {
        }
    }
}