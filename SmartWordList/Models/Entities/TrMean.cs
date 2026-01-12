namespace SmartWordList.Models.Entities
{
    public class TrMean
    {
        public int Id { get; set; }

        public string Mean { get; set; }

        public int? WordId { get; set; }

        public Word? Word { get; set; }
    }
}
