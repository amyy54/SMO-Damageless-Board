using Microsoft.AspNetCore.Mvc.RazorPages;
using Speedrun.API;
using Speedrun.Types;

namespace SMO_Damageless_Board.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private Leaderboard? Leaderboard { get; set; }
    public List<ViewableData> Data { get; set; } = new List<ViewableData>();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGetAsync()
    {
        var client = new SpeedrunAPI();
        Leaderboard = await client.GetLeaderboard("m1mxxw46", "9kv98382"); // Super Mario Odyssey Category Extensions, Damageless.
        if (Leaderboard != null)
        {
            foreach (Runs runs in Leaderboard.data.runs)
            {
                var mooncount = (int)(runs.run.times.primary_t * 1000 > 880 ? 880 : runs.run.times.primary_t * 1000);
                string? time = null;
                if (mooncount == 880 && !string.IsNullOrWhiteSpace(runs.run.comment))
                {
                    time = runs.run.comment.Split("\n")[0].Trim();
                    if (!char.IsDigit(time[0])) time = null; // If the comment does not start with a number, it cannot not include the time in a format acceptable for the site.
                }
                // https://www.speedrun.com/api/v1/games/m1mxxw46/variables
                string version = runs.run.values.onv6y608 switch
                {
                    "q65kk2nl" => "1.4.1",
                    "1dk7v84l" => "1.4.0",
                    "jq6xp6oq" => "1.3.0",
                    "z194ykjl" => "1.2.0",
                    "klrz49w1" => "1.1.0",
                    "814xgjwq" => "1.0.0",
                    _ => "1.4.1" // Assume the latest version if the version is not known.
                };
                string? playerId = runs.run.players[0].rel == "user" ? runs.run.players[0].id : null;
                string playerName = "Unknown";
                string playerWeblink = "https://www.speedrun.com";
                if (playerId != null)
                {
                    Player? player = Leaderboard.data.players.data.FirstOrDefault(player => player.id == playerId);
                    if (player != null)
                    {
                        playerName = player.names.international;
                        playerWeblink = player.weblink;
                    }
                }
                Data.Add(new ViewableData
                {
                    Place = runs.place,
                    Time = time,
                    Version = version,
                    MoonCount = mooncount,
                    Player = playerName,
                    PlayerWebLink = playerWeblink,
                    Date = runs.run.date,
                    Weblink = runs.run.weblink
                });
            }
        }
    }
}
