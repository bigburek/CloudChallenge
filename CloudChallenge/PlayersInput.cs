using CsvHelper.Configuration.Attributes;

namespace CloudChallenge
{
    //Class structure for reading the csv file
    public class PlayersInput
    {
        [Name("PLAYER")]
        public string? Player { get; set; }

        [Name("POSITION")]
        public string? Position { get; set; }

        [Name("FTM")]
        public float FreeThrowsMade { get; set; }

        [Name("FTA")]
        public float FreeThrowsAttempted { get; set; }

        [Name("2PM")]
        public float TwoPointMade { get; set; }

        [Name("2PA")]
        public float TwoPointAttempted { get; set; }

        [Name("3PM")]
        public float ThreePointMade { get; set; }

        [Name("3PA")]
        public float ThreePointAttempted { get; set; }

        [Name("REB")]
        public float Rebounds { get; set; }

        [Name("BLK")]
        public float Blocks { get; set; }

        [Name("AST")]
        public float Assists { get; set; }

        [Name("STL")]
        public float Steals { get; set; }

        [Name("TOV")]
        public float Turnovers { get; set; }
    }
}
