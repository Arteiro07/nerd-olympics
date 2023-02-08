using NerdOlympics.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace NerdOlympics.Data
{
    public class NerdOlympicsDBContext : DbContext
    {
        public NerdOlympicsDBContext(DbContextOptions<NerdOlympicsDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Competition>? Competitions { get; set; }
        public DbSet<Record>? Records { get; set; }
        public DbSet<User>? Users { get; set; }
    }
}
