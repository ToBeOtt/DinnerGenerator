using MatGenerator.Models;
using Newtonsoft.Json;

namespace MatGenerator.Data
{
    public static class DinnerData
    {
        public static string GetDinnerFilepath()
        {
            return @"C:\Users\tacri\OneDrive\Skrivbord\MatApp\MatGenerator\DinnerData.txt";
        }


        public static void SaveDinnerToFile(Dinner dinner)
        {
            string json = JsonConvert.SerializeObject(dinner, Newtonsoft.Json.Formatting.Indented);
            

            try
            {
                if (!File.Exists(GetDinnerFilepath()))
                {
                    File.WriteAllText(GetDinnerFilepath(), json);
                }
                else
                {
                    var existingData = File.ReadAllText(GetDinnerFilepath());
                    var dinners = JsonConvert.DeserializeObject<List<Dinner>>(existingData) ?? new List<Dinner>();
                    dinners.Add(dinner);
                    json = JsonConvert.SerializeObject(dinners, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(GetDinnerFilepath(), json);
                }

                Console.WriteLine("Måltid sparad!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }
        }

        public static void WriteToFile(string filePath, string content)
        {
            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    // Create a new file and write the content to it
                    File.WriteAllText(filePath, content);
                }
                else
                {
                    // Append content if file already exists
                    File.AppendAllText(filePath, content);
                }

                Console.WriteLine("File written successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }


    }
}
