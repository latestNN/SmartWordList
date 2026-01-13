using SmartWordList.Models.Authentication;

namespace SmartWordList.Models.Entities
{
    public class WordList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Category { get; set; } //TODO: Enum yapilacak.

        public string? Organisation { get; set; }

        public string? LogoUrl { get; set; }



        public List<Word>? Words { get; set; }
        public List<PartialWordList>? PartialWordLists { get; set; }

        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

    }
}
