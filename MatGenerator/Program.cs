using MatGenerator.Application;

namespace MatGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.WriteLine("1. Lägg till måltid");
                Console.WriteLine("2. Ta bort måltid");
                Console.WriteLine("3. Se alla måltider");
                Console.WriteLine("4. Generera matvecka");
                Console.WriteLine("5. Avsluta");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDinnerManager.AddDinner();

                        break;
                    case "2":
                        DeleteDinnerManager.DeleteDinner();
                        break;
                    case "3":
                        DisplayDinnersManager.DisplayAllDinners();
                        break;
                    case "4":
                        GenerateDinnerManager.GenerateDinners();
                        break;
                    case "5":
                        exitProgram = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, välj alternativ 1-5.");
                        break;
                }
            }
        }
    }
}
