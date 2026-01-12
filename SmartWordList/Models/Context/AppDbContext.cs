using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartWordList.Models.Authentication;
using SmartWordList.Models.Entities;

namespace SmartWordList.Models.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Word> words { get; set; }

        public DbSet<TrMean> trMeans { get; set; }

        public DbSet<UserWord> userWords { get; set; }

        public DbSet<WordList> wordLists { get; set; }
        public DbSet<WeekPartialWordList> WeekPartialWordLists { get; set; }

        public DbSet<PartialWordList> partialWordLists { get; set; }
    }
}
