using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAdminRepository Admins { get; }
        IBonusRepository Bonuses { get; }       
        ICommentRepository Comments { get; }
        ICompanyRepository Companies { get; }
        IDebitRepository Debits { get; }
        IEmailRepository Emails { get; }
        IExpenseRepository Expenses { get; }
        IFileRepository Files { get; }
        INotificationRepository Notifications { get; }
        IOffDayRepository OffDays { get; }
        IShiftRepository Shifts { get; }
        IUserRepository Users { get; }

        Task<int> CommitAsync();
    }
}
