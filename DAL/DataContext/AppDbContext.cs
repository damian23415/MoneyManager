using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DTO.Money;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DAL.DataContext
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<IncomeDTO> Income { get; set; }
        public DbSet<ExpensesDTO> Expense { get; set; }
        public DbSet<SummaryDTO> Summary { get; set; }
    }
}
