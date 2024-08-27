using Microsoft.EntityFrameworkCore;
using RowLevelSecuritySample.EntityFramework;
using RowLevelSecuritySample.Services;
using RowLevelSecuritySample.Services.Interfaces;

namespace RowLevelSecuritySample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDbContext<RowLevelSecurityDbContext>(options =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext")));

            AddRepositoryServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }

        private static void AddRepositoryServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
        }
    }
}
