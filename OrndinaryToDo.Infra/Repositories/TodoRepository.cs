using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrndinaryToDo.Domain.Entities;
using OrndinaryToDo.Domain.Queries;
using OrndinaryToDo.Domain.Repositories;
using OrndinaryToDo.Infra.Contexts;

namespace OrndinaryToDo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;

        public TodoRepository(DataContext dataContext) => _dataContext = dataContext;
        public void Create(TodoItem todo)
        {
            _dataContext.Todos.Add(todo);
            _dataContext.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _dataContext.Todos.AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllTasks(string user)
        {
            //.AsNoTracking() when result should be a SELECT only
            return _dataContext.Todos.AsNoTracking()
            .Where(TodoQueries.GetAllTasks(user))
            .OrderBy(x => x.Date);
        }
        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _dataContext.Todos.AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _dataContext.Todos.FirstOrDefault(x => x.Id.Equals(id) && x.User.Equals(user));
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _dataContext.Todos.AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, date, done))
            .OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _dataContext.Entry(todo).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }
    }
}