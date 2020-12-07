using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIIInlinetable.Models
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options):base(options)
        {}

        public DbSet<CBank> Banks { get; set; }
        public DbSet<CBankAccount> BankAccounts { get; set; }
    }
}
