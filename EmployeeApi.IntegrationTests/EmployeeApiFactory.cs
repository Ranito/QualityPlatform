using EmployeeApi.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace EmployeeApi.IntegrationTests
{
    public class EmployeeApiFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove o DbContext original
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<EmployeeDbContext>)
                );

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Regista DB em memória para testes
                services.AddDbContext<EmployeeDbContext>(options =>
                {
                    options.UseInMemoryDatabase("EmployeeTestDb");
                });

                // Cria a DB
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();
                db.Database.EnsureCreated();
            });
        }
    }
}
