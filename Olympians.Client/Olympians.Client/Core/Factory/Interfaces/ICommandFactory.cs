using Olympians.Client.Core.Commands;
using Olympians.Client.Core.Commands.Interfaces;
using Olympians.Client.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympians.Client.Core.Factory.Interfaces
{
    public interface ICommandFactory
    {
        public ICommand CreateCommand(CommandType type);
    }
}
