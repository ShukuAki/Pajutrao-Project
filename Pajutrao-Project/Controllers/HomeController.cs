using Microsoft.AspNetCore.Mvc;
using Pajutrao_Project.Models;
using System.Diagnostics;
using Pajutrao_Project.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Pajutrao_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Login()
        {
            // Render the login view
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            var isValidUser = _userService.ValidateUser(username, password);

            if (isValidUser)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Return a success response with redirection URL
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }
            else
            {
                return Json(new { success = false, message = "Invalid username or password." });
            }
        }


        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            _logger.LogInformation("User is authenticated and accessing the Index page.");
            return View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            // Sign out and redirect to login page
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult LoD()
        {

            return View();
        }


        [HttpPost]
        [Route("api/updateLoD")]
        public async Task<IActionResult> UpdateLoD([FromBody] LoDRequest request)
        {
            bool isLoD = request.IsLoD;

            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    user.Ufda = isLoD; // Update UFda to the value of isLoD
                    context.SaveChanges();
                }
            }

            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("api/updateCanvas")]
        public async Task<IActionResult> UpdateCanvas([FromBody] LoDRequest request)
        {
            bool isLoD = request.IsLoD;

            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    user.Ucanv = isLoD; // Update UFda to the value of isLoD
                    context.SaveChanges();
                }
            }

            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("api/updateDatabase")]
        public async Task<IActionResult> UpdateDatabase([FromBody] LoDRequest request)
        {
            bool isLoD = request.IsLoD;

            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    user.Udbf = isLoD; // Update UFda to the value of isLoD
                    context.SaveChanges();
                }
            }

            return Ok(new { success = true });
        }

        [HttpPost]
        [Route("api/updateLogistics")]
        public async Task<IActionResult> UpdateLogistics([FromBody] LoDRequest request)
        {
            bool isLoD = request.IsLoD;

            var username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    user.Ulog = isLoD; // Update UFda to the value of isLoD
                    context.SaveChanges();
                }
            }

            return Ok(new { success = true });
        }




        // Method to get LoD status
        [HttpGet]
        public IActionResult GetLoDStatus()
        {
            var username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    return Json(new { isLoD = user.Ufda });
                }
            }

            return NotFound();
        }

        // Method to get Canvas status
        [HttpGet]
        public IActionResult GetCanvasStatus()
        {
            var username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    return Json(new { isCanv = user.Ucanv });
                }
            }

            return NotFound();
        }

        // Method to get Logistics status
        [HttpGet]
        public IActionResult GetLogisticsStatus()
        {
            var username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    return Json(new { isLog = user.Ulog });
                }
            }

            return NotFound();
        }

        // Method to get Database status
        [HttpGet]
        public IActionResult GetDatabaseStatus()
        {
            var username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            using (var context = new FourtifyContext())
            {
                var user = context.Accounts.FirstOrDefault(u => u.AccName == username);
                if (user != null)
                {
                    return Json(new { isDBF = user.Udbf });
                }
            }

            return NotFound();
        }



        [Authorize]
        public IActionResult Logistics()
        {

            return View();
        }
        [Authorize]
        public IActionResult Database()
        {

            return View();
        }
        [Authorize]
        public IActionResult Canvas()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
