using MatGenerator.Data;
using MatGenerator.Models;

namespace MatGenerator.Application
{
    public class AddDinnerManager
    {
        public static void AddDinner()
        {
            Console.Clear();
            Console.WriteLine("Namn på måltid:");
            string dinnerName = Console.ReadLine(); Console.Clear();


            string[] categories = {"Kött", "Fisk", "Soppa", "Sallad", "Övrigt"};
            Console.WriteLine("Välj kategori för måltid:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            string categoryName = "";
            string choice = Console.ReadLine();
            int chosenIndex;
            if (int.TryParse(choice, out chosenIndex) && chosenIndex >= 1 && chosenIndex <= categories.Length)
            {
                categoryName = categories[chosenIndex - 1];

                Console.Clear();
                Console.WriteLine("Vegetarisk?");
                Console.WriteLine("1 - Ja");
                Console.WriteLine("2 - Nej");
                Console.Write(": ");
                var response = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (response != 1 && response != 2)
                {
                    Console.WriteLine("Ogiltigt svar. Försök igen.");
                    AddDinner();
                }

                bool isVegetarian = false;
                if (response == 1)
                {
                    isVegetarian = true;
                }
                else 
                {
                    isVegetarian = false;
                }

                Console.WriteLine("Ytterligare måltidsinfo?:");
                string dinnerNote = Console.ReadLine(); Console.Clear();


                Dinner dinner = new Dinner(dinnerName, dinnerNote, categoryName, isVegetarian);
                DinnerData.SaveDinnerToFile(dinner);

                Console.WriteLine($"Måltid '{dinnerName}' tillagd till kategori: '{categoryName}'.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ogiltigt val");
            }
        }
    }
}
