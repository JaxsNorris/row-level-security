using Microsoft.EntityFrameworkCore;
using RowLevelSecuritySample.Models;

namespace RowLevelSecuritySample.EntityFramework
{
    public class RowLevelSecurityDbContext(DbContextOptions<RowLevelSecurityDbContext> options, IHttpContextAccessor httpContextAccessor) : DbContext(options)
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new SessionContextDbConnectionInterceptor(_httpContextAccessor));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TenantModel> Tenants { get; set; }
        public DbSet<ApplicationModel> Applications { get; set; }
        public DbSet<ApplicationFileModel> ApplicationFiles { get; set; }
    }
}

