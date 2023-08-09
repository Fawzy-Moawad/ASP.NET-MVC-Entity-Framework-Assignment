using YourProjectNamespace.Models;

public void ConfigureServices(IServiceCollection services)
{
    // ...

    services.AddDbContext<YourDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("YourDbContextConnection")));

    // ...
}
