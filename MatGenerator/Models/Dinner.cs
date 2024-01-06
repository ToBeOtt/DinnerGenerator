namespace MatGenerator.Models
{
    public class Dinner
    {
        public string DinnerName { get; set; }
        public string? DinnerNote { get; set;}
        public string DinnerCategory { get; set; }
        public bool IsVegetarian { get; set; }

        public Dinner
            (string dinnerName, 
            string? dinnerNote,
            string dinnerCategory,
            bool isVegetarian)
        {
            DinnerName = dinnerName;

            if (dinnerNote != null)
                DinnerNote = dinnerNote;

            DinnerCategory = dinnerCategory;
            IsVegetarian = isVegetarian;
        }
    }
    
}
