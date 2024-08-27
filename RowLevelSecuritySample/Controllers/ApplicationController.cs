using Microsoft.AspNetCore.Mvc;
using RowLevelSecuritySample.Models.Dto;
using RowLevelSecuritySample.Services.Interfaces;

namespace RowLevelSecuritySample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController(ILogger<ApplicationController> logger, IApplicationRepository applicationRepository, IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        [HttpGet(Name = "GetApplications")]
        public async Task<IEnumerable<ApplicationDTO>> Get()
        {
            var userId = httpContextAccessor.HttpContext!.Request.Headers.SingleOrDefault(h => h.Key == "user-id");
            logger.LogInformation("someone {userId} is trying to access application", userId);
            var list = await applicationRepository.GetAll();
            return list.Select(app => ApplicationDTO.MapFrom(app));
        }
    }
}
