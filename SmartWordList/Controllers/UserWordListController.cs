using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWordList.Models.Authentication;
using SmartWordList.Models.Context;

namespace SmartWordList.Controllers
{
    public class UserWordListController : Controller
    {
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
            var partialUserWordLists = _context.partialWordLists.Include(y => y.WordList).Where(x => x.AppUserId == user.Id).ToList();
            return View(partialUserWordLists);
        }
    }
}
