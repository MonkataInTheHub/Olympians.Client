using Olympians.Client.Core.Commands.Interfaces;
using Olympians.Client.Core.Factory.Interfaces;
using Olympians.Models;
using Olympians.Models.Enums;
using Olympians.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Olympians.Client.Core.Commands
{
    public class CreateBoxerCommand : ICommand
    {
        readonly IOlympiansFactory _olympiansFactory;

        public CreateBoxerCommand(IOlympiansFactory olympiansFactory )
        {
            _olympiansFactory = olympiansFactory;
        }

        public async Task ExecuteAsync(List<string> parameters, Writer writer)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            string country = parameters[2];
            Category boxingCategory = Enum.Parse<Category>(parameters[3], true);
            int wins = int.Parse(parameters[4]);
            int losses = int.Parse(parameters[5]);

            var boxer = _olympiansFactory.CreateBoxer(firstName, lastName, country, boxingCategory, wins, losses);

            var json = JsonSerializer.Serialize(boxer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:7071/api/Boxer";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            writer.WriteLine($"Created boxer");
            writer.WriteLine("");

        }

    }
}
