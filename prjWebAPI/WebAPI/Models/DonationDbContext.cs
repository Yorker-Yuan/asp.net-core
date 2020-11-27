using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DonationDbContext:DbContext
    {
        public DonationDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<DCandidate> DCandidates { get; set; }
    }
}
