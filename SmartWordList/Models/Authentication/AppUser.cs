using Microsoft.AspNetCore.Identity;
using SmartWordList.Models.Entities;

namespace SmartWordList.Models.Authentication
{
    public class AppUser : IdentityUser
    {
        public List<WordList> WordLists { get; set; }

        public List<PartialWordList> PartialWordLists { get; set; }


    }
}
