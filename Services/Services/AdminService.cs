using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        UserManager<User> userManager;

        public AdminService(IUnitOfWork _unitOfWork, UserManager<User> _userManager)
        {
            this.unitOfWork = _unitOfWork;
            this.userManager = _userManager;
        }

        public Task<bool> SetUserStatus(Guid userID)
        {
            User user = (User)unitOfWork.Users.List(x => x.Id == userID);
            if (!user.IsActive)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

    }
}
