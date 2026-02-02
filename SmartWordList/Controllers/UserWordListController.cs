using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWordList.Models.Authentication;
using SmartWordList.Models.Context;
using SmartWordList.Models.ViewModels;

namespace SmartWordList.Controllers
{
    public class UserWordListController : Controller
    {
        int QuestionCount = 0;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public UserWordListController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserWordLists()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var partialUserWordLists = _context.partialWordLists.Include(y => y.WordList).Include(z => z.WeekPartialWordLists).Where(x => x.AppUserId == user.Id).ToList();

            return View(partialUserWordLists);
        }

        public IActionResult UserWeakWordList(int id)
        {
            var word = _context.WeekPartialWordLists.Include(x => x.UserWords).ThenInclude(y => y.Word).Where(z => z.Id == id).ToList();
            TempData["weakListId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult UserWordListTest(QuizSettingsViewModel model)
        {
            int weakListId = 0;
            if(TempData["weakListId"] is int value)
            {
                weakListId = value;
            }
            
            TempData["WordCount"] = model.TestQuestionCount;
            return RedirectToAction("UserWeakWordListQuiz" , new { weakListId = weakListId });
        }

        public IActionResult UserWeakWordListQuiz(int weakListId)
        {
            int wordCount = (int)TempData["WordCount"];
            wordCount = 10;
            if (QuestionCount < wordCount)
            {
                QuestionCount++;
                var word = _context.userWords.Include(x => x.Word).ThenInclude(y => y.TrMeans).Where(z => z.WeekPartialWordListId == weakListId).FirstOrDefault();
                return View(word);
            }
            else
            {
                return RedirectToAction("Stats");
            } 
        }


        [HttpPost]
        public IActionResult UserWordListPractise(int id)
        {
            var word = _context.WeekPartialWordLists.Include(x => x.UserWords).ThenInclude(y => y.Word).Where(z => z.Id == id).ToList();
            ViewBag.weakList = _context.WeekPartialWordLists.Find(id);
            return View();
        }

    }
}
