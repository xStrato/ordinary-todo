using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrndinaryToDo.Domain.Entities;
using OrndinaryToDo.Domain.Queries;

namespace OrndinaryToDo.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private List<TodoItem> _items;
        public TodoQueriesTests()
        {
            _items = new List<TodoItem>
            {
                new TodoItem("Task 1", "User 1", DateTime.Now),
                new TodoItem("Task 2", "User 2", DateTime.Now),
                new TodoItem("Task 3", "XXX", DateTime.Now),
                new TodoItem("Task 4", "User 4", DateTime.Now),
                new TodoItem("Task 5", "XXX", DateTime.Now)
            };
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Should_Return_Tasks_From_User_XXX()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllTasks("XXX"));
            Assert.AreEqual(2, result.Count());
        }
    }
}