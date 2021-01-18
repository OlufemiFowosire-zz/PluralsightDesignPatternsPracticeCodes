using System;
using System.Collections.Generic;

namespace ShoppingCart.Business.Commands
{
    public class CommandManager
    {
        private readonly Stack<ICommand> doCommands;
        private readonly Stack<ICommand> redoCommands;

        public int DoCommandsCount => doCommands.Count;
        public int RedoCommandsCount => redoCommands.Count;

        public CommandManager()
        {
            doCommands = new Stack<ICommand>();
            redoCommands = new Stack<ICommand>();
        }

        public void Invoke(ICommand command)
        {
            doCommands.Push(command);
            command.Execute();
        }

        public void Undo()
        {
            var command = doCommands.Pop();
            redoCommands.Push(command);
            command.Undo();
        }

        public void Redo()
        {
            var command = redoCommands.Pop();
            doCommands.Push(command);
            command.Execute();
        }
    }
}
