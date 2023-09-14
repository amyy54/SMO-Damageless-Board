using Speedrun.Types;

namespace Speedrun.API
{
    public class SpeedrunAPI
    {
        private HttpClient client { get; set; }

        public SpeedrunAPI()
        {
            client = new HttpClient();
        }

        public async Task<Leaderboard?> GetLeaderboard(string gameID, string categoryID)
        {
            var content = await client.GetAsync($"https://www.speedrun.com/api/v1/leaderboards/{gameID}/category/{categoryID}?embed=players");
            var json = await content.Content.ReadFromJsonAsync<Leaderboard>();
            return json;
        }
    }
}
