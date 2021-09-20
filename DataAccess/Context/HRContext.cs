using Core.Entities;
using Core.Model.Authentication;
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

        public DbSet<Company> Companies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DayOff> Vacations { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Debit> Debits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

    }
}
