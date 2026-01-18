using Microsoft.AspNetCore.Identity.UI.Services;

namespace HealthBookTracker.Infrastructure.Services;

public class FakeEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine("====== EMAIL ======");
        Console.WriteLine($"TO: {email}");
        Console.WriteLine($"SUBJECT: {subject}");
        Console.WriteLine(htmlMessage);
        Console.WriteLine("===================");

        return Task.CompletedTask;
    }
}