using Olympians.Client.Core.Commands.Interfaces;
using Olympians.Models;
using Olympians.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Olympians.Client.Core.Commands
{
    public class ListOlympiansCommand : ICommand
    {

        public async Task ExecuteAsync(List<string> parameters, Writer writer)
        {

            var olympians = await AddAllOlympiansAsync();

            ApplyOrder(parameters, ref olympians);

            PrintOlympians(olympians, writer);

        }
        private void ApplyOrder(List<string> parameters, ref List<IOlympian> olympians)
        {
            if (parameters.Count == 0)
            {
                olympians = olympians.OrderBy(x => x.FirstName).ToList();
            }
            else if (parameters.Count > 1 && parameters[1] == "desc")
            {
                if (parameters[0] == "lastname")
                {
                    olympians = olympians.OrderByDescending(x => x.LastName).ToList();
                }
                else if (parameters[0] == "country")
                {
                    olympians = olympians.OrderByDescending(x => x.Country).ToList();
                }
                else
                {
                    olympians = olympians.OrderByDescending(x => x.FirstName).ToList();
                }
            }
            else if (parameters.Count == 1 || parameters[1] == "asc")
            {
                if (parameters[0] == "lastname")
                {
                    olympians = olympians.OrderBy(x => x.LastName).ToList();
                }
                else if (parameters[0] == "country")
                {
                    olympians = olympians.OrderBy(x => x.Country).ToList();
                }
                else
                {
                    olympians = olympians.OrderBy(x => x.FirstName).ToList();
                }
            }

        }

        public void PrintOlympians(List<IOlympian> olympians, Writer writer)
        {
            if (olympians.Count == 0)
            {
                writer.WriteLine("There aren't any olympians");
                writer.WriteLine("");
            }
            else
            {
                writer.WriteLine("Olympians:");
                writer.WriteLine("");

                foreach (var olympian in olympians)
                {
                    writer.WriteLine(olympian.ToString());
                }
            }
        }

        public async Task<List<IOlympian>> AddAllOlympiansAsync()
        {
            var olympians = new List<IOlympian>();
            olympians.AddRange(await AddAllOlympiansOfType<Boxer>());
            olympians.AddRange(await AddAllOlympiansOfType<Sprinter>());

            return olympians;
        }
 
        public async Task<List<T>> AddAllOlympiansOfType<T>()
        {
            string type = typeof(T).Name;
            var url = $"https://localhost:7071/api/{type}/GetAll{type}s";
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            var olympians = JsonConvert.DeserializeObject<List<T>>(result);

            return olympians;
        }
    }
}
