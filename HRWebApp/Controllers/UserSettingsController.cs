using HRWebApp.Model.VMs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRWebApp.Controllers
{
    public class UserSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCompany(List<CompanyVM> companyVMs)
        {
            return PartialView("GetCompany", companyVMs);
        }

    }
}
