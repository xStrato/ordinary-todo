using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrndinaryToDo.Domain.Commands;

namespace OrndinaryToDo.Tests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Bem-Vindo", "xStrato", DateTime.Now);

        // Constructor case Tests always use Validated commands, else should commented
        public CreateTodoCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Given_An_Invalid_Command()
        {
            // _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Given_A_Valid_Command()
        {
            // _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
