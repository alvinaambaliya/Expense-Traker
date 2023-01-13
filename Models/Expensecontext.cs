using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Expensetracker.Models
{
    public class Expensecontext : DbContext
    {
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Expense_limit> expense_limits { get; set; }
    }
}