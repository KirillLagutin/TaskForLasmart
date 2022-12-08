using Microsoft.EntityFrameworkCore;
using TaskForLasmart.Domain.Entities;

namespace TaskForLasmart.Data.Ef.Data
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
            : base(options) { }

        public DbSet<Point> Points => Set<Point>();
        public DbSet<Comment> Comments => Set<Comment>();
    }
}