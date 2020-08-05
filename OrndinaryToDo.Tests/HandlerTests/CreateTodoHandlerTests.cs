using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrndinaryToDo.Domain.Commands;
using OrndinaryToDo.Domain.Handlers;
using OrndinaryToDo.Tests.Repositories;

namespace OrndinaryToDo.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Welcome", "xStrato", DateTime.Now);

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        [TestMethod]
        [TestCategory("Handler")]
        public void Given_An_Invalid_Command_Should_Stop_Execution()
        {
            var result = (CommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Sucess, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public void Given_A_Valid_Command_Should_Complete_Task()
        {
            var result = (CommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Sucess, true);
        }
    }
}