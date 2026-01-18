using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HealthBookTracker.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using System.Net.Http;
using System.Linq;

namespace HealthBookTracker.Tests
{
    public class AccountControllerTests
    {
        private readonly HttpClient _client;

        public AccountControllerTests()
        {
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // Указываем абсолютный путь к проекту WebUI
                    builder.UseContentRoot(@"E:\Рабочий стол\HealthBookTracker\HealthBookTracker.WebUI");

                    // Подменяем DB на InMemory
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                        if (descriptor != null)
                            services.Remove(descriptor);

                        services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");
                        });
                    });
                });

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Login_ReturnsSuccess()
        {
            var response = await _client.GetAsync("/Account/Login");
            response.EnsureSuccessStatusCode();
        }
    }
}