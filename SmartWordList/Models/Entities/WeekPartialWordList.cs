using SmartWordList.Models.Authentication;

namespace SmartWordList.Models.Entities
{
    public class WeekPartialWordList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WeekNumber { get; set; }

        public List<UserWord>? UserWords { get; set; }

        public int? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
