using System.Text.Json;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using IW4MAdminSupportBot.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IW4MAdminSupportBot;

// Credit: https://github.com/discord-net/Discord.Net/tree/dev/samples
internal static class Program
{
    private static void Main() => MainAsync().GetAwaiter().GetResult();

    private static async Task MainAsync()
    {
        await using var services = ConfigureServices();
        var client = services.GetRequiredService<DiscordSocketClient>();

        client.Log += LogAsync;
        services.GetRequiredService<CommandService>().Log += LogAsync;

        var fileJson = await File.ReadAllTextAsync("BotConfiguration.json");
        var token = JsonSerializer.Deserialize<BotConfiguration>(fileJson);

        await client.LoginAsync(TokenType.Bot, token?.Token);
        await client.StartAsync();
        await services.GetRequiredService<CommandHandlingService>().InitializeAsync();
        await Task.Delay(Timeout.Infinite);
    }

    private static async Task LogAsync(LogMessage log) => Console.WriteLine(log.ToString());

    private static ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton(new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            })
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandService>()
            .AddSingleton<CommandHandlingService>()
            .AddSingleton<HttpClient>()
            .BuildServiceProvider();
    }
}

public class BotConfiguration
{
    public string Token { get; set; } = null!;
}
