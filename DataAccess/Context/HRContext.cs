using Core.Entities;
using Core.Model.Authentication;
using DataAccess.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class HRContext : IdentityDbContext<User, Role, Guid>
    {
        public HRContext(DbContextOptions<HRContext> dbContext) : base(dbContext) { }

        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<DayOff> DayOffs { get; set; }
        public DbSet<DayOffType> DayOffTypes { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<UserShift> UserShifts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //SeedContext.Initialize();

            builder.ApplyConfiguration(new BonusConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new DayOffConfiguration());
            builder.ApplyConfiguration(new DayOffTypeConfiguration());
            builder.ApplyConfiguration(new DebitConfiguration());
            builder.ApplyConfiguration(new ExpenseConfiguration());
            builder.ApplyConfiguration(new FileConfiguration());
            builder.ApplyConfiguration(new FileTypeConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            builder.ApplyConfiguration(new PlanConfiguration());
            builder.ApplyConfiguration(new ShiftConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserShiftConfiguration());

            base.OnModelCreating(builder);
        }

    }
}
