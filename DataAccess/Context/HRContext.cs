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
    public class HRContext : IdentityDbContext<User, IdentityRole, string>
    {
        public HRContext(DbContextOptions<HRContext> dbContext) : base(dbContext) { }

        public DbSet<Bonus> Bonus { get; set; }
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyConfiguration());

        }

    }
}
