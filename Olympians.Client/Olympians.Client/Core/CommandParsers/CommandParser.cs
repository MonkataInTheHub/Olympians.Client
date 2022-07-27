using Olympians.Client.Core.CommandParsers.Interfaces;
using Olympians.Client.Core.Commands.Interfaces;
using Olympians.Client.Core.Enums;
using Olympians.Client.Core.Factory.Interfaces;

namespace Olympians.Client.Core.CommandParsers
{
    public class CommandParser : ICommandParser
    {
        readonly ICommandFactory _commandFactory;
        public CommandParser(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }
        public ICommand ParseCommand(string nameOfCommand)
        {
            if (!Enum.TryParse(nameOfCommand, true, out CommandType commandType))
            {
                throw new ArgumentOutOfRangeException("The provided command type is not yet supported!");
            }

            return _commandFactory.CreateCommand(commandType);
        }
        public List<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();

            if (commandParts.Count() == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
