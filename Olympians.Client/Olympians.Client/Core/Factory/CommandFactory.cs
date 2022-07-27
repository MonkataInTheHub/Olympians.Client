using Olympians.Client.Core.Commands;
using Olympians.Client.Core.Commands.Interfaces;
using Olympians.Client.Core.Enums;
using Olympians.Client.Core.Factory.Interfaces;
using Olympians.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympians.Client.Core.Factory
{
    public class CommandFactory : ICommandFactory
    {
        readonly IOlympiansFactory _olympiansFactory;
        readonly IOlympicsDatabase _olympiansDatabase;
        public CommandFactory(IOlympiansFactory olympiansFactory, IOlympicsDatabase olympicsDatabase)
        {
            _olympiansFactory = olympiansFactory;
            _olympiansDatabase = olympicsDatabase;
        }

        public ICommand CreateCommand(CommandType type)
        {
            switch (type)
            {
                case CommandType.CreateBoxer:
                    return new CreateBoxerCommand(_olympiansFactory);
                case CommandType.CreateSprinter:
                    return new CreateSprinterCommand(_olympiansFactory);
                case CommandType.ListOlympians:
                    return new ListOlympiansCommand();

            }

            throw new ArgumentOutOfRangeException("The provided command type is not yet supported!");
        }
    }
}
