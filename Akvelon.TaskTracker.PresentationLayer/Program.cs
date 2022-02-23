using Akvelon.TaskTracker.DataAccessLayer.DataContext;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
                
        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Adding database context
        services.AddDbContext<TaskTrackerDbContext>(options => 
            options.UseNpgsql(Configuration.GetConnectionString("ConnectionString")));
    }

        

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}