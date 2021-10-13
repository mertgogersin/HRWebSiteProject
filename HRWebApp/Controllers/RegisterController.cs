using Core.Settings;
using HRWebApp.Model.JwtValidator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        
        public IActionResult RegisterEmployer(string token)
        {
            TokenValidator tokenValidator = new TokenValidator(appSettings);
            string userID = tokenValidator.ValidateUser(token);
            if(userID == null)
            {
                TempData["expiredToken"] = "Your email is expired please try again";
                return RedirectToAction("Index", "HomePage");
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:11404");
                var content = new StringContent(userID, Encoding.UTF8, "application/json");
                var response = client.PostAsync("/api/User/ValidateEmployer/", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Your account has been activated. You can sign in now.";
                    HttpContext.Session.SetString("userID", userID);
                }
                return RedirectToAction("Index", "HomePage");
            }
        }
    }
}
