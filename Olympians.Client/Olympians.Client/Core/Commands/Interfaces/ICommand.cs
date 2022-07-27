using Olympians.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympians.Client.Core.Commands.Interfaces
{
    public interface ICommand
    {
        Task ExecuteAsync(List<string> parameters, Writer writer);
    }
}
