using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ReactProject.Models
{
    public class DbContextCandidate:DbContext
    {
        public DbContextCandidate(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<DCandidate> dCandidates { get; set; }
    }
}
