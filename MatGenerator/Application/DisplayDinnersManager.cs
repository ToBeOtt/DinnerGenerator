using MatGenerator.Data;
using MatGenerator.Models;
using Newtonsoft.Json;

namespace MatGenerator.Application
{
    public class DisplayDinnersManager
    {
        private static string filePath = DinnerData.GetDinnerFilepath();
        public static void DisplayAllDinners()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var dinners = JsonConvert.DeserializeObject<List<Dinner>>(jsonData) ?? new List<Dinner>();

                if (dinners.Any())
                {
                    Console.WriteLine("\nTillgängliga måltider:");
                    foreach (var dinner in dinners)
                    {
                        Console.WriteLine($"- {dinner.DinnerName}");
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Inga måltider finns lagrade.");
                }
            }
            else
            {
                Console.WriteLine("Ingen måltidfil hittades.");
            }
        }
    }
}
