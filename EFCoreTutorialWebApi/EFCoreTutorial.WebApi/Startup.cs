using EFCoreTutorial.Common;
using EFCoreTutorial.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration =configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(conf =>
            {
                conf.UseSqlServer(StringConstants.DbConnectionString);
                conf.EnableSensitiveDataLogging();
            });

        }
    }
}
