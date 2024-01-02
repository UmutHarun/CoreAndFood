using CoreAndFood.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreAndFood.Controllers
{
    public class AccountController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Login(Admin a)
		{
            var dataValue = c.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
			if(dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, a.UserName),
                };

                var UserIdentity = new ClaimsIdentity(claims, "Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);    

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
		}

		public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout() 
        {
			await HttpContext.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}
    }
}
