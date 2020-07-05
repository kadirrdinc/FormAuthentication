using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FormAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FormAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var login = _context.Users.ToList().Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();

                if (login != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Email,model.Email),
                        new Claim(ClaimTypes.Name,login.FirstName+" "+login.LastName),
                        new Claim(ClaimTypes.Role,login.UserRoleID.ToString())
                    };

                    var denemeIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var userPrincipal = new ClaimsPrincipal(new[] { denemeIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    return RedirectToAction("Index", "Home");
                }

                return View(model);
            }
            catch (Exception exception)
            {
                return View(exception);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            //HttpContext.Response.Cookies.Delete("");
            return RedirectToAction("Login", "Home");
        }
    }
}
