using Newtonsoft.Json;

namespace CloudChallenge
{
    // Classes structure for the response
    public class PlayerStats
    {
        [JsonProperty("playerName")]
        public string? PlayerName { get; set; }

        [JsonProperty("gamesPlayed")]
        public int GamesPlayed { get; set; }

        [JsonProperty("traditional")]
        public TraditionalStats? Traditional { get; set; }

        [JsonProperty("advanced")]
        public AdvancedStats? Advanced { get; set; }
    }

    public class TraditionalStats
    {
        [JsonProperty("freeThrows")]
        public FreeThrows? FreeThrows { get; set; }

        [JsonProperty("twoPoints")]
        public TwoPoints? TwoPoints { get; set; }

        [JsonProperty("threePoints")]
        public ThreePoints? ThreePoints { get; set; }

        [JsonProperty("points")]
        public float Points { get; set; }

        [JsonProperty("rebounds")]
        public float Rebounds { get; set; }

        [JsonProperty("blocks")]
        public float Blocks { get; set; }

        [JsonProperty("assists")]
        public float Assists { get; set; }

        [JsonProperty("steals")]
        public float Steals { get; set; }

        [JsonProperty("turnovers")]
        public float Turnovers { get; set; }
    }

    public class FreeThrows
    {
        [JsonProperty("attempts")]
        public float Attempts { get; set; }

        [JsonProperty("made")]
        public float Made { get; set; }

        [JsonProperty("shootingPercentage")]
        public float ShootingPercentage { get; set; }
    }

    public class TwoPoints
    {
        [JsonProperty("attempts")]
        public float Attempts { get; set; }

        [JsonProperty("made")]
        public float Made { get; set; }

        [JsonProperty("shootingPercentage")]
        public float ShootingPercentage { get; set; }
    }

    public class ThreePoints
    {
        [JsonProperty("attempts")]
        public float Attempts { get; set; }

        [JsonProperty("made")]
        public float Made { get; set; }

        [JsonProperty("shootingPercentage")]
        public float ShootingPercentage { get; set; }
    }

    public class AdvancedStats
    {
        [JsonProperty("valorization")]
        public float Valorization { get; set; }

        [JsonProperty("effectiveFieldGoalPercentage")]
        public float EffectiveFieldGoalPercentage { get; set; }

        [JsonProperty("trueShootingPercentage")]
        public float TrueShootingPercentage { get; set; }

        [JsonProperty("hollingerAssistRatio")]
        public float HollingerAssistRatio { get; set; }
    }

    public class PlayerAverages
    {
        public float FTM { get; set; }
        public float FTA { get; set; }
        public float FTP { get; set; }
        public float TwoPM { get; set; }
        public float TwoPA { get; set; }
        public float TwoPP { get; set; }
        public float ThreePM { get; set; }
        public float ThreePA { get; set; }
        public float ThreePP { get; set; }
        public float REB { get; set; }
        public float BLK { get; set; }
        public float AST { get; set; }
        public float STL { get; set; }
        public float TOV { get; set; }
        public float PTS { get; set; }
        public float VAL { get; set; }
        public float eFGP { get; set; }
        public float TSP { get; set; }
        public float hASTP { get; set; }
    }
}
