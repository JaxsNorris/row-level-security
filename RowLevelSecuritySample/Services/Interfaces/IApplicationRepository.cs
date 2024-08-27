using RowLevelSecuritySample.Models;

namespace RowLevelSecuritySample.Services.Interfaces
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ApplicationModel>> GetAll();
    }
}