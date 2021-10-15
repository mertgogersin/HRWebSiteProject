using Core.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HRWebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppSettings appSettings;
        public RegisterController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult RegisterEmployer(string id)
        {
            if (id == null)
            {
                TempData["expiredToken"] = "Your email is expired please try again";
                return RedirectToAction("Index", "HomePage");
            }
            TempData["success"] = "Your account has been activated. You can sign in now.";
            HttpContext.Session.SetString("userID", id);
            return RedirectToAction("Index", "HomePage");

        }
    }
}
