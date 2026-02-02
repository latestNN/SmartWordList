using SmartWordList.Models.Authentication;

namespace SmartWordList.Models.Entities
{
    public class WeekPartialWordList // Partial word listlerin haftalık olarak bölünmüş halleri.
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WeekNumber { get; set; }

        public int? PartialWordListId { get; set; }

        public PartialWordList? PartialWordList { get; set; }

        public List<UserWord> UserWords { get; set; }

        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public WeekPartialWordList()
        {
            UserWords = new List<UserWord>();
        }
    }
}
