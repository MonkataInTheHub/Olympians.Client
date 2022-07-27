using Olympians.Client.Core.Factory.Interfaces;
using Olympians.Models;
using Olympians.Models.Enums;
using Olympians.Models.Interfaces;

namespace Olympians.Client.Core.Factory
{
    public class OlympiansFactory : IOlympiansFactory
    {
        public Boxer CreateBoxer(string firstName, string lastName, string country,
            Category boxingCategory, int wins, int losses)
        {
            return new Boxer(firstName, lastName, country, boxingCategory, wins, losses);
        }

        public Sprinter CreateSprinter(string firstName, string lastName,
            string country, Dictionary<string, string> records)
        {
            return new Sprinter(firstName, lastName, country, records);
        }
    }
}
