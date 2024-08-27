using Microsoft.EntityFrameworkCore;
using RowLevelSecuritySample.EntityFramework;
using RowLevelSecuritySample.Models;
using RowLevelSecuritySample.Services.Interfaces;

namespace RowLevelSecuritySample.Services
{
    public class ApplicationRepository(RowLevelSecurityDbContext dbContext) : IApplicationRepository
    {
        public async Task<IEnumerable<ApplicationModel>> GetAll()
        {
            return await dbContext.Applications
                 .Include(a => a.Tenant)
                 .Include(a => a.ApplicationFiles)
                 .ToListAsync();

        }
    }
}
