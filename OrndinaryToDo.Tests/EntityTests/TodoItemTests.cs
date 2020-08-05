using System;
using OrndinaryToDo.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrndinaryToDo.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        private readonly TodoItem _todo = new TodoItem("Wealcome", "xStrato", DateTime.Now);

        [TestMethod]
        [TestCategory("Entity")]
        public void Given_A_New_Todo_That_Are_Not_Completed()
        {
            Assert.AreEqual(_todo.Done, false);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Given_A_New_Todo_That_Are_Completed()
        {
            _todo.MarkAsDone();
            Assert.AreEqual(_todo.Done, true);
        }
    }
}