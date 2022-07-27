using Olympians.Client.Core.Commands.Interfaces;
using Olympians.Client.Core.Factory.Interfaces;
using Olympians.Models;
using Olympians.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Olympians.Client.Core.Commands
{
    public class CreateSprinterCommand : ICommand
    {
        readonly IOlympiansFactory _olympiansFactory;

        public CreateSprinterCommand(IOlympiansFactory olympiansFactory)
        {
            _olympiansFactory = olympiansFactory;
        }

        public async Task ExecuteAsync(List<string> parameters, Writer writer)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            string country = parameters[2];
            var personalRecords = new Dictionary<string, string>();

            for (int i = 3; i < parameters.Count; i+=2)
            {
                personalRecords.Add(parameters[i], parameters[i+1]);
            }

            var sprinter = _olympiansFactory.CreateSprinter(firstName, lastName, country, personalRecords);

            var json = JsonSerializer.Serialize(sprinter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7071/api/Sprinter";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            writer.WriteLine($"Created sprinter");
            writer.WriteLine("");
        }
    }
}
