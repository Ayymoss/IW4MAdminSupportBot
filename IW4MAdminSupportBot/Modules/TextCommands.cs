using Discord.Commands;

namespace IW4MAdminSupportBot.Modules;

public class TextCommands : ModuleBase<SocketCommandContext>
{
    [Command("ping")]
    public async Task PingAsync() => await ReplyAsync("pong!");

    [Command("help")]
    public async Task HelpAsync() => await ReplyAsync("List of commands: \n" +
                                                      "```yml\n" +
                                                      "$faq - Provides the link for FAQ.\n" +
                                                      "$maxretry - FAQ for \"Could not communicate\" & \"Reached maximum retry attempts\"\n" +
                                                      "$commands - FAQ for commands not responding in-game.\n" +
                                                      "$nodvar - FAQ on fail to get dvar value for version.\n" +
                                                      "$addserver - FAQ on how to add more servers to IW4MAdmin.\n\n" +
                                                      "$ping - Checks whether the bot is online.\n" +
                                                      "```");

    [Command("faq")]
    public async Task FaqAsync() => await ReplyAsync("https://github.com/RaidMax/IW4M-Admin/wiki/FAQ");
    
    [Command("maxretry"), Alias("nocommunicate")]
    public async Task MaxRetryAsync() => await ReplyAsync("https://github.com/RaidMax/IW4M-Admin/wiki/FAQ#could-not-communicate-with-ipport--reached-maximum-retry-attempts-to-send-rcon-data-to-server");
    
    [Command("commands")]
    public async Task CommandsAsync() => await ReplyAsync("https://github.com/RaidMax/IW4M-Admin/wiki/FAQ#commands-not-responding");
    
    [Command("nodvar")]
    public async Task NoDvarAsync() => await ReplyAsync("https://github.com/RaidMax/IW4M-Admin/wiki/FAQ#could-not-get-the-dvar-value-for-version");
    
    [Command("addserver")]
    public async Task AddServerAsync() => await ReplyAsync("https://github.com/RaidMax/IW4M-Admin/wiki/FAQ#how-do-i-add-more-servers-after-iw4madmin-is-already-configured");
}
