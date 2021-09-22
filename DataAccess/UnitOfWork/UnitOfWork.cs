using Core.Repositories;
using Core.UnitOfWork;
using DataAccess.Context;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRContext context;
        private AdminRepository adminRepository;
        private BonusRepository bonusRepository;     
        private CommentRepository commentRepository;
        private CompanyRepository companyRepository;
        private DebitRepository debitRepository;
        private EmailRepository emailRepository;
        private ExpenseRepository expenseRepository;
        private FileRepository fileRepository;
        private NotificationRepository notificationRepository;
        private OffDayRepository offDayRepository;
        private ShiftRepository shiftRepository;
        private UserRepository userRepository;

        public UnitOfWork(HRContext context)
        {
            this.context = context;
        }

        public IAdminRepository Admins => adminRepository = adminRepository ?? new AdminRepository(context);

        public IBonusRepository Bonuses => bonusRepository = bonusRepository ?? new BonusRepository(context);
      

        public ICommentRepository Comments => commentRepository = commentRepository ?? new CommentRepository(context);

        public ICompanyRepository Companies => companyRepository = companyRepository ?? new CompanyRepository(context);

        public IDebitRepository Debits => debitRepository = debitRepository ?? new DebitRepository(context);

        public IEmailRepository Emails => emailRepository = emailRepository ?? new EmailRepository(context);

        public IExpenseRepository Expenses => expenseRepository = expenseRepository ?? new ExpenseRepository();

        public IFileRepository Files => fileRepository = fileRepository ?? new FileRepository();

        public INotificationRepository Notifications => notificationRepository = notificationRepository ?? new NotificationRepository();

        public IOffDayRepository OffDays => offDayRepository = offDayRepository ?? new OffDayRepository();

        public IShiftRepository Shifts => shiftRepository = shiftRepository ?? new ShiftRepository();

        public IUserRepository Users => userRepository = userRepository ?? new UserRepository();

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
