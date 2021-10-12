using HRWebApp.Model.VMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HRWebApp.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetCompanyLogosPartial(List<CompanyLogoVM> companyLogoVMs)
        {
            return PartialView("GetCompanyLogosPartial", companyLogoVMs);
        }
    }
}
