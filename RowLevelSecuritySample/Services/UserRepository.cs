using Microsoft.EntityFrameworkCore;
using RowLevelSecuritySample.EntityFramework;
using RowLevelSecuritySample.Models;
using RowLevelSecuritySample.Services.Interfaces;

namespace RowLevelSecuritySample.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly RowLevelSecurityDbContext _dbContext;

        public UserRepository(RowLevelSecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UserModel> GetUser(int userId)
        {
            return _dbContext.Users
                .Include(u => u.Tenant)
                .SingleAsync(u => u.UserId == userId);

        }
    }
}
