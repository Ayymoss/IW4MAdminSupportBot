using Discord.Commands;

namespace IW4MAdminSupportBot.Modules;

public class TextCommands : ModuleBase<SocketCommandContext>
{
    [Command("ping")]
    public async Task PingAsync() => await ReplyAsync("pong!");

    [Command("faq")]
    public async Task CatAsync() => await ReplyAsync("pong!");
}
