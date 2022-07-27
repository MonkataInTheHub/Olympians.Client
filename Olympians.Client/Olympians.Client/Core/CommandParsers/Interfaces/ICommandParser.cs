using Olympians.Client.Core.Commands.Interfaces;

namespace Olympians.Client.Core.CommandParsers.Interfaces
{
    public interface ICommandParser
    {
        public ICommand ParseCommand(string nameOfCommand);
        public List<string> ParseParameters(string fullCommand);
    }
}
