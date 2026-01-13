using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWordList.Models.Authentication;
using SmartWordList.Models.Context;
using SmartWordList.Models.Entities;

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

        public IActionResult WordListTest(int id)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var worldList = _context.wordLists.FirstOrDefault(x => x.Id == id);
            if(user == null || worldList == null)
            {
                if(user.WordLists.Any(x => x.Name == worldList.Name))
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

        public IActionResult SaveWordToPartial(int id)
        {
            var word = _context.words.FirstOrDefault(x => x.Id == id);
            if(word == null)
            {
                var user = _userManager.GetUserAsync(User).Result;
                var partialWordList = user.PartialWordLists.Where(x => x.WordListId == word.WordListId).FirstOrDefault();
                TempData["PartialWordListId"] = partialWordList.Id;
                partialWordList.Words.Add(word);
                _context.SaveChanges();
            }
            int wordListId = Convert.ToInt32(TempData["wordListId"]);
            return RedirectToAction("WordListTest", new {id = wordListId });
        }

        public IActionResult CreateWeekPartialWordList()
        {
            var user = _userManager.GetUserAsync(User).Result;
            int partialWordListId = Convert.ToInt32(TempData["PartialWordListId"]);
            var partialWordList = _context.partialWordLists.Include(x => x.Words).FirstOrDefault(x => x.Id == partialWordListId);
            int wordCount = partialWordList.Words.Count;
            int count = 0;
            int weekNumber = 0;
            var weekPartialWordList = new WeekPartialWordList() { };
            foreach (var word in partialWordList.Words)
            {
                if(count == 0 || count == 5)
                {
                    weekPartialWordList.AppUserId = user.Id;
                    weekNumber++;
                    weekPartialWordList.Name = "Week - " + weekNumber.ToString();
                    weekPartialWordList.WeekNumber = weekNumber;

                }
                UserWord userWord = new UserWord()
                {
                    WordId = word.Id,
                    WeekPartialWordListId = weekPartialWordList.Id
                };
                weekPartialWordList.UserWords.Add(userWord);
                count++;
                if(count == 5 || count == wordCount)
                {
                    _context.WeekPartialWordLists.Add(weekPartialWordList);
                    _context.SaveChanges();
                }
            }
            
            return RedirectToAction("Index", "Home");
        }
    }


}
