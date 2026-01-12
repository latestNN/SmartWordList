using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartWordList.Models.Authentication;
using SmartWordList.Models.ViewModels;

namespace SmartWordList.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserSignInViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, userModel.Sifre);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userModel.Email);
                if(user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userModel.Sifre, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                
            }
            ModelState.AddModelError("", "Email veya şifre hatalı.");
            return View(userModel);
        }
    }
}
