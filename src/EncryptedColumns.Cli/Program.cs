using EncryptedColumns.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.AddDataAccess(context.Configuration);
});

var host = builder.Build();

using (host)
{
    await host.StartAsync();
    
    var dbContext = host.Services.GetRequiredService<AppDbContext>();

    var users = await dbContext.Users.ToListAsync();

    var u = new User
    {
        SocialSecurityNumber = "123-45-6789"
    };

    dbContext.Users.Add(u);

    await dbContext.SaveChangesAsync();

    await host.StopAsync();
}
