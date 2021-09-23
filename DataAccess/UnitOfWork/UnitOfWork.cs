using Core.EmailSenderManager;
using Core.Repositories;
using Core.UnitOfWork;
using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRContext context;
        private readonly EmailSettings emailSettings;

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

        public UnitOfWork(HRContext context, IOptions<EmailSettings> emailSettings)
        {
            this.context = context;
            this.emailSettings = emailSettings.Value;
        }

        public IBonusRepository Bonuses => bonusRepository = bonusRepository ?? new BonusRepository(context);

        public ICommentRepository Comments => commentRepository = commentRepository ?? new CommentRepository(context);

        public ICompanyRepository Companies => companyRepository = companyRepository ?? new CompanyRepository(context);

        public IDebitRepository Debits => debitRepository = debitRepository ?? new DebitRepository(context);

        public IEmailRepository Emails => emailRepository = emailRepository ?? new EmailRepository(context, emailSettings);

        public IExpenseRepository Expenses => expenseRepository = expenseRepository ?? new ExpenseRepository(context);

        public IFileRepository Files => fileRepository = fileRepository ?? new FileRepository(context);

        public INotificationRepository Notifications => notificationRepository = notificationRepository ?? new NotificationRepository(context);

        public IOffDayRepository OffDays => offDayRepository = offDayRepository ?? new OffDayRepository(context);

        public IShiftRepository Shifts => shiftRepository = shiftRepository ?? new ShiftRepository(context);

        public IUserRepository Users => userRepository = userRepository ?? new UserRepository(context);

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
