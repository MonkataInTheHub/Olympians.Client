using Olympians.Client.Core;
using Olympians.Client.Core.CommandParsers;
using Olympians.Client.Core.Factory;
using Olympians.Models.Databases;

namespace Olympians.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Singleton design pattern
            // Ensures that there is only one instance of Engine in existance
            var olympiansFactory = new OlympiansFactory();
            var olympiansDatabase = new OlympianDatabase();
            var commandFactory = new CommandFactory(olympiansFactory, olympiansDatabase);
            var commandParser = new CommandParser(commandFactory);
            var engine = new Engine(commandParser);
            engine.Start();
        }
    }
}