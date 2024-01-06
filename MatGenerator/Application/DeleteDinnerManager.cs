using MatGenerator.Data;
using MatGenerator.Models;
using Newtonsoft.Json;

namespace MatGenerator.Application
{
    public class DeleteDinnerManager
    {
        private static string filePath = DinnerData.GetDinnerFilepath();

        public static void DeleteDinner()
        {
            bool stayInDeleteMenu = true;

            while (stayInDeleteMenu)
            {
                Console.Clear();
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Ta bort en måltid");
                Console.WriteLine("2. Återgå till huvudmenyn");
                Console.Write(": ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DeleteSpecificMeal();
                        break;
                    case "2":
                        stayInDeleteMenu = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void DeleteSpecificMeal()
        {
            Console.Clear();
            Console.WriteLine("\nAnge namnet på måltiden som ska tas bort:");
            string dinnerName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(dinnerName))
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        var jsonData = File.ReadAllText(filePath);
                        var dinners = JsonConvert.DeserializeObject<List<Dinner>>(jsonData) ?? new List<Dinner>();

                        var dinnerToRemove = dinners.FirstOrDefault(d => d.DinnerName.Equals(dinnerName, StringComparison.OrdinalIgnoreCase));
                        if (dinnerToRemove != null)
                        {
                            dinners.Remove(dinnerToRemove);
                            string updatedJson = JsonConvert.SerializeObject(dinners, Formatting.Indented);
                            File.WriteAllText(filePath, updatedJson);
                            Console.WriteLine($"Måltiden '{dinnerName}' har tagits bort.");
                        }
                        else
                        {
                            Console.WriteLine("Måltiden hittades inte.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingen måltidfil hittades.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Inget namn angavs.");
            }

            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
        }

    }
}
