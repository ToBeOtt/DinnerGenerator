using MatGenerator.Data;
using MatGenerator.Models;
using Newtonsoft.Json;

namespace MatGenerator.Application
{
    public class GenerateDinnerManager
    {
        private static string filePath = DinnerData.GetDinnerFilepath();
        private static Random random = new Random();
        public static void GenerateDinners()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                var dinners = JsonConvert.DeserializeObject<List<Dinner>>(jsonData) ?? new List<Dinner>();

                if (dinners.Any())
                {
                    WeekDinnerGenerator(dinners);
                }
                else
                {
                    // skicka tillbaka error att ingen måltid finns för dag.
                    Console.WriteLine("Inga måltider finns lagrade.");
                }
            }
            else
            {
                Console.WriteLine("Ingen måltidfil hittades.");
            }
        }


        private static void WeekDinnerGenerator(List<Dinner> dinners)
        {
            string[] WeekdayArray = { "Monday", "Tisdag", "Onsdag", "Torsdag", "Fredag" };

            Dictionary<string, Dinner> WeekOfPlannedDinners = new Dictionary<string, Dinner>();

            // Monday
            WeekOfPlannedDinners.Add(WeekdayArray[0], DinnerOfMonday(dinners));
            // Tuesday
            WeekOfPlannedDinners.Add(WeekdayArray[1], DinnerOfTuesday(dinners));
            // Wednesday
            WeekOfPlannedDinners.Add(WeekdayArray[2], DinnerOfWednesday(dinners));
            // Thursday
            WeekOfPlannedDinners.Add(WeekdayArray[3], DinnerOfThursdays(dinners));
            // Friday
            WeekOfPlannedDinners.Add(WeekdayArray[4], DinnerOfFridays(dinners));

            Console.Clear();
            foreach(var day in WeekOfPlannedDinners)
            {
                Console.WriteLine($"\n{day.Key}: {day.Value.DinnerName} - ({day.Value.DinnerCategory})\n");
            }
            Console.ReadKey();
        }

        private static Dinner DinnerRandomizer(List<Dinner> dinners)
        {
            int randomIndex = random.Next(dinners.Count);
            return dinners[randomIndex];
        }

        private static Dinner DinnerOfMonday(List<Dinner> dinners)
        {
            var mondayDinners = dinners.Where(d => d.IsVegetarian == true).ToList();
            return DinnerRandomizer(mondayDinners);
        }

        private static Dinner DinnerOfTuesday(List<Dinner> dinners)
        {
            var TuesdayDinners = dinners.Where(d => d.DinnerCategory == "Fisk").ToList();
            return DinnerRandomizer(TuesdayDinners);
        }

        private static Dinner DinnerOfWednesday(List<Dinner> dinners)
        {
            var wednesdayDinners = dinners.Where(d => d.DinnerCategory == "Soppa").ToList();
            return DinnerRandomizer(wednesdayDinners);
        }

        private static Dinner DinnerOfThursdays(List<Dinner> dinners)
        {
            var ThursdayDinners = dinners.Where(d => d.DinnerCategory == "Kött").ToList();
            return DinnerRandomizer(ThursdayDinners);
        }

        private static Dinner DinnerOfFridays(List<Dinner> dinners)
        {
            var FridayDinners = dinners.ToList();
            return DinnerRandomizer(FridayDinners);
        }
    }
}
