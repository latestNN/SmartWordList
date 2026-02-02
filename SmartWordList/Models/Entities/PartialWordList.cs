using SmartWordList.Models.Authentication;

namespace SmartWordList.Models.Entities
{
    public enum ListLevel
    {
        A1 = 1,
        A2 = 2,
        B1 = 3,
        B2 = 4,
        C1 = 5
    }
    public class PartialWordList // Büyük word listlerinin kullanıcılara göre özelleştirilmiş hali.
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ListLevel? ListLevel { get; set; }

        public DateTime CreatedTime { get; set; }

        public string? Weak { get; set; }

        public decimal SuccessAnswerCount { get; set; } = 0;

        public decimal WrongAnswerCount { get; set; } = 0;

        public decimal SuccesPercent { get; set; } = 0;

        public int? WordListId { get; set; }

        public WordList? WordList { get; set; }

        public List<UserWord> UserWords { get; set; }
        public List<WeekPartialWordList> WeekPartialWordLists { get; set; }

        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
