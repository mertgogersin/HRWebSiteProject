using Core.Model.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public static class SeedContext
    {

        public async static void Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            await roleManager.CreateAsync(new Role { Name = "Employee" });
            await roleManager.CreateAsync(new Role { Name = "Employer" });
        }
    }
}
