namespace Speedrun.Types
{
    public class ViewableData
    {
        public int Place { get; set; }
        public string? Time { get; set; }
        public string Version { get; set; } = null!;
        public int MoonCount { get; set; }
        public string Player { get; set; } = null!;
        public string PlayerWebLink { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string Weblink { get; set; } = null!;
    }

    public class Values
    {
        // Version
        public string onv6y608 { get; set; } = null!;
    }

    public class PlayerEmbed
    {
        public string id { get; set; } = null!;
        public string rel { get; set; } = null!;
        public string uri { get; set; } = null!;
    }

    public class Names
    {
        public string international { get; set; } = null!;
        public string? japanese { get; set; }
        public string? twitch { get; set; }
    }

    public class Player
    {
        public string rel { get; set; } = null!;
        public string id { get; set; } = null!;
        public Names names { get; set; } = null!;
        public string? pronouns { get; set; }
        public string weblink { get; set; } = null!;
    }

    public class Times
    {
        public string primary { get; set; } = null!;
        public float primary_t { get; set; }
        public string realtime { get; set; } = null!;
        public float realtime_t { get; set; }
    }

    public class Run
    {
        public string id { get; set; } = null!;
        public string weblink { get; set; } = null!;
        public string game { get; set; } = null!;
        public string? level { get; set; }
        public string category { get; set; } = null!;
        public string? comment { get; set; }
        public PlayerEmbed[] players { get; set; } = null!;
        public string date { get; set; } = null!;
        public string submitted { get; set; } = null!;
        public Times times { get; set; } = null!;
        public Values values { get; set; } = null!;
    }

    public class Runs
    {
        public int place { get; set; }
        public Run run { get; set; } = null!;
    }

    public class PlayerData
    {
        public Player[] data { get; set; } = null!;
    }

    public class Data
    {
        public Runs[] runs { get; set; } = null!;
        public PlayerData players { get; set; } = null!;
    }

    public class Leaderboard
    {
        public Data data { get; set; } = null!;
    }
}
