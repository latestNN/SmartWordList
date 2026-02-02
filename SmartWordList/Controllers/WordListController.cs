using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWordList.Models.Authentication;
using SmartWordList.Models.Context;
using SmartWordList.Models.Entities;
using System.Threading.Tasks;

namespace SmartWordList.Controllers
{
    public class WordListController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public WordListController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var wordLists = _context.wordLists.ToList();
            return View(wordLists);
        }

        public IActionResult WordListProfile(int id)
        {
            ViewBag.wordList = _context.wordLists.FirstOrDefault(x => x.Id == id);
            var words = _context.words.Include(x => x.TrMeans).Where(x => x.WordListId == id).ToList();
            return View(words);
        }

        public async Task<IActionResult> WordListTest(int id)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.Users.Include(x => x.PartialWordLists).FirstOrDefaultAsync(x => x.Id == userId);
            var worldList = _context.wordLists.FirstOrDefault(x => x.Id == id);
            if(user != null && worldList != null)
            {
                bool exists = user.PartialWordLists.Any(x => x.WordListId == worldList.Id);
                if (exists == false)
                {
                    PartialWordList partialWordList = new PartialWordList()
                    {
                        Name = worldList.Name,
                        CreatedTime = DateTime.Now,
                        WordListId = worldList.Id,
                        AppUser = user

                    };
                    _context.partialWordLists.Add(partialWordList);
                    _context.SaveChanges();
                }

                
            }
            
            TempData["wordListId"] = id;
            int count = 0;
            ViewBag.wordTh += count;
            ViewBag.listLength = _context.words.Where(x => x.WordListId == id).Count();
            ViewBag.word = _context.words.Include(x => x.TrMeans).Include(z => z.WordList).Where(y => y.WordListId == id).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            return View();
        }

        public async Task<IActionResult> SaveWordToPartialAsync(int id)
        {
            var word = _context.words.FirstOrDefault(x => x.Id == id);
            if(word != null)
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.Users.Include(x => x.PartialWordLists).FirstOrDefaultAsync(x => x.Id == userId);
                var partialWordList = user.PartialWordLists.Where(x => x.WordListId == word.WordListId).FirstOrDefault();
                UserWord userWord = new UserWord()
                {
                    WordId = word.Id,
                    PartialWordListId = partialWordList.Id
                };
                
                TempData["PartialWordListId"] = partialWordList.Id;
                _context.userWords.Add(userWord);
                _context.SaveChanges();
            }
            int wordListId = Convert.ToInt32(TempData["wordListId"]);
            return RedirectToAction("WordListTest", new {id = wordListId });
        }

        public async Task<IActionResult> CreateWeekPartialWordListAsync()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.Users.Include(x => x.PartialWordLists).FirstOrDefaultAsync(x => x.Id == userId);
            int partialWordListId = Convert.ToInt32(TempData["PartialWordListId"]);
            var partialWordList = _context.partialWordLists.Include(x => x.UserWords).FirstOrDefault(x => x.Id == partialWordListId);
            int wordCount = partialWordList.UserWords.Count();
            int count = 1;
            int weekNumber = 1;
            WeekPartialWordList weekPartialWordList = new WeekPartialWordList() 
            {
                AppUserId = user.Id,
                Name = "Week - " + weekNumber.ToString(),
                WeekNumber = weekNumber,
                PartialWordListId = partialWordList.Id

            };
      
            foreach (var word in partialWordList.UserWords)
            {
                if(count == 5)
                {
                    weekPartialWordList = new WeekPartialWordList() 
                    { 
                        AppUserId = user.Id,
                        Name = "Week - " + weekNumber.ToString(),
                        WeekNumber = ++weekNumber,
                        PartialWordListId = partialWordList.Id
                    }; 
                    count = 1;

                }

                weekPartialWordList.UserWords.Add(word);
                count++;
                if(count == 5 || count == wordCount)
                {
                    _context.WeekPartialWordLists.Add(weekPartialWordList);
                    _context.SaveChanges();
                }
            }
            
            return RedirectToAction("UserWordLists", "UserWordList");
        }
    }


}
