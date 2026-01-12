using Microsoft.AspNetCore.Mvc;
using SmartWordList.Models.Context;

namespace SmartWordList.ViewComponents
{
    public class WordMeanListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public WordMeanListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int wordId)
        {
            var word = _context.trMeans.Where(x => x.WordId == wordId).ToList();
            return View(word);
        }
    }
}
