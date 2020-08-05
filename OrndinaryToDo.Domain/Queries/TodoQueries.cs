using System;
using System.Linq.Expressions;
using OrndinaryToDo.Domain.Entities;

namespace OrndinaryToDo.Domain.Queries
{
    public static class TodoQueries
    {
        public static Expression<Func<TodoItem, bool>> GetAllTasks(string user) => (x => x.User.Equals(user));
        public static Expression<Func<TodoItem, bool>> GetAllDone(string user) => (x => x.User.Equals(user) && x.Done);
        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user) => (x => x.User.Equals(user) && !x.Done);
        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done) => (x => x.User.Equals(user) && x.Done.Equals(done) && x.Date.Equals(date));
    }
}