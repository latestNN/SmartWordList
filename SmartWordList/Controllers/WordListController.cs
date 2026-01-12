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
            
            
            int count = 0;
            ViewBag.wordTh += count;
            ViewBag.listLength = _context.words.Where(x => x.WordListId == id).Count();
            ViewBag.word = _context.words.Include(x => x.TrMeans).Include(z => z.WordList).Where(y => y.WordListId == id).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            return View();
        }

        public IActionResult SaveWordToPartial(int id)
        {
            
            return View();
        }
    }


}
