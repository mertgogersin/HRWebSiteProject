using Core.Entities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAdminService
    {
        Task<bool> SetUserStatus(Guid userID);

    }
}
