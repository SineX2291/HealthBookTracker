using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http;
using Xunit;

namespace HealthBookTracker.Tests
{
    public class AccountControllerTests
    {
        private readonly HttpClient _client;

        public AccountControllerTests()
        {
            // WebApplicationFactory с указанием контента проекта
            var factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    // Укажи абсолютный путь к папке WebUI
                    builder.UseContentRoot(@"E:\Рабочий стол\HealthBookTracker\HealthBookTracker.WebUI");
                });

            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Login_ReturnsSuccess()
        {
            // Делаем GET-запрос на страницу /Account/Login
            var response = await _client.GetAsync("/Account/Login");

            // Проверяем, что код ответа 200 OK
            response.EnsureSuccessStatusCode();
        }
    }
}

