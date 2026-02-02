using Microsoft.AspNetCore.Identity;
using SmartWordList.Models.Entities;

namespace SmartWordList.Models.Authentication
{
    public class AppUser : IdentityUser
    {

        public List<PartialWordList> PartialWordLists { get; set; }

        public List<WeekPartialWordList> WeekPartialWordLists { get; set; }


    }
}
