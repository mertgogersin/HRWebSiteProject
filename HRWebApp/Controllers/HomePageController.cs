using HRWebApp.Model.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HRWebApp.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            if (TempData.ContainsKey("expiredToken"))
            {
                ViewBag.Message = TempData["expiredToken"].ToString();
            }
            if(TempData.ContainsKey("success"))
            {
                ViewBag.Message = TempData["success"].ToString();
            }
            return View();
        }
        public IActionResult GetCompanyLogosPartial(List<CompanyLogoVM> companyLogoVMs)
        {
            return PartialView("GetCompanyLogosPartial", companyLogoVMs);
        }
    }
}
