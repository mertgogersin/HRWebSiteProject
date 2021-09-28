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

        public Task SetUserStatus(Guid userID)
        {
            throw new NotImplementedException();
        }
    }
}
