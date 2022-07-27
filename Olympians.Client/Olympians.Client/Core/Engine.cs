using Olympians.Client.Core.CommandParsers.Interfaces;
using Olympians.Client.Core.Interfaces;
using System.Text;

namespace Olympians.Client.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser _commandParser;
        private const string _terminationCommand = "Exit";
        private const string _nullProvidersExceptionMessage = "cannot be null.";
        private StringBuilder _builder = new StringBuilder();

        
        public Engine(ICommandParser commandParser)
        {
            _commandParser = commandParser;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = Console.ReadLine();

                    if (commandAsString.ToLower() == _terminationCommand.ToLower())
                    {
                        Console.Write(this._builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this._builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var parameters = this._commandParser.ParseParameters(commandAsString);
            var command = this._commandParser.ParseCommand(parameters[0]);
            parameters.RemoveAt(0);

            command.ExecuteAsync(parameters, new Models.Writer());
        }
    }
}
