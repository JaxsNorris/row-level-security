using RowLevelSecuritySample.Models;

namespace RowLevelSecuritySample.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> GetUser(int userId);
    }
}