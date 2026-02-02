namespace SmartWordList.Models.Entities
{
    public enum WordLevel
    {
        A1 = 1,
        A2 = 2,
        B1 = 3,
        B2 = 4,
        C1 = 5
    }
    public class Word
    {
        public int Id { get; set; }

        public string EngWord { get; set; }

        public WordLevel? Level { get; set; }

        public string? Category { get; set; } //TODO: kategoriler enum yapiacal.


        public bool Connective { get; set; } = false;


        public List<TrMean> TrMeans { get; set; }

        public int? WordListId { get; set; }

        public WordList? WordList { get; set; }

        public List<UserWord> UserWords { get; set; }
    }
}
