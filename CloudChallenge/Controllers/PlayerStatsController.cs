using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CloudChallenge.Controllers
{
    [ApiController]
    [Route("stats")]
    public class PlayerStatsController : Controller
    {
        private readonly ILogger<PlayerStatsController> _logger;
        public PlayerStatsController(ILogger<PlayerStatsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllPlayers")] // /stats endpoint
        public IEnumerable<PlayersInput> Get()
        {
            return PlayerData.playersData; //returning the csv data
        }
        

        [HttpGet("player/{playerFullName}")] // /stats/player/{playerFullName} endpoint
        public IActionResult GetPlayerStats(string playerFullName)
        {

            var matchingPlayers = PlayerData.playersData?
                .Where(p => p.Player.Equals(playerFullName, StringComparison.OrdinalIgnoreCase))
                .ToList();

            //Searching for playerFullName
            if (matchingPlayers == null || matchingPlayers.Count == 0)
            {
                _logger.LogWarning($"No player found with full name '{playerFullName}'.");
                return NotFound("Player not found"); //Returning 400
            }

            PlayerAverages avgs = new PlayerAverages();

            //Creating the response object using functions
            var newPlayerStats = new PlayerStats
            {
                PlayerName = playerFullName,
                GamesPlayed = matchingPlayers.Count,
                Traditional = CalculateTraditionalStats(matchingPlayers, avgs),
                Advanced = CalculateAdvancedStats(matchingPlayers, avgs)
            };
           
            return Ok(newPlayerStats); //Returning 200
        }

        //Returning TraditionalStats object, doing calculations
        private TraditionalStats CalculateTraditionalStats(List<PlayersInput> players, PlayerAverages averages) 
        {
            averages.FTM = players.Average(p => p.FreeThrowsMade);
            averages.FTA = players.Average(p => p.FreeThrowsAttempted);
            averages.FTP = averages.FTM / averages.FTA * 100;

            averages.TwoPM = players.Average(p => p.TwoPointMade);
            averages.TwoPA = players.Average(p => p.TwoPointAttempted);
            averages.TwoPP = averages.TwoPM / averages.TwoPA * 100;

            averages.ThreePM = players.Average(p => p.ThreePointMade);
            averages.ThreePA = players.Average(p => p.ThreePointAttempted);
            averages.ThreePP = averages.ThreePM / averages.ThreePA * 100;

            averages.REB = players.Average(p => p.Rebounds);
            averages.BLK = players.Average(p => p.Blocks);
            averages.AST = players.Average(p => p.Assists);
            averages.STL = players.Average(p => p.Steals);
            averages.TOV = players.Average(p => p.Turnovers);
            averages.PTS = averages.FTM + 2 * averages.TwoPM + 3 * averages.ThreePM;

            return new TraditionalStats
            {
                FreeThrows = new FreeThrows
                {
                    Attempts = (float)Math.Round(averages.FTA,1),
                    Made = (float)Math.Round(averages.FTM, 1),
                    ShootingPercentage = (float)Math.Round(averages.FTP,1),
                },
                TwoPoints = new TwoPoints
                {
                    Attempts = (float)Math.Round(averages.TwoPA, 1),
                    Made = (float)Math.Round(averages.TwoPM, 1),
                    ShootingPercentage = (float)Math.Round(averages.TwoPP,1),
                },
                ThreePoints = new ThreePoints
                {
                    Attempts = (float)Math.Round(averages.ThreePA, 1),
                    Made = (float)Math.Round(averages.ThreePM, 1),
                    ShootingPercentage = (float)Math.Round(averages.ThreePP,1)
                },
                Points = (float)Math.Round(averages.PTS, 1),
                Rebounds = (float)Math.Round(averages.REB, 1),
                Blocks = (float)Math.Round(averages.BLK, 1),
                Assists = (float)Math.Round(averages.AST, 1),
                Steals = (float)Math.Round(averages.STL, 1),
                Turnovers = (float)Math.Round(averages.TOV,1)
            };

        }
        //Returning AdvancedStats object, doing calculations
        private AdvancedStats CalculateAdvancedStats(List<PlayersInput> players, PlayerAverages averages)
        {

            return new AdvancedStats
            {
                Valorization = (float)Math.Round(averages.FTM + 2 * averages.TwoPM + 3 * averages.ThreePM + averages.REB + averages.BLK + averages.AST + averages.STL - (averages.FTA - averages.FTM + averages.TwoPA - averages.TwoPM + averages.ThreePA - averages.ThreePM + averages.TOV),1),
                EffectiveFieldGoalPercentage = (float)Math.Round((averages.TwoPM + averages.ThreePM + 0.5f * averages.ThreePM) / (averages.TwoPA + averages.ThreePA) * 100,1),
                TrueShootingPercentage = (float)Math.Round(averages.PTS / (2 * (averages.TwoPA + averages.ThreePA + 0.475f * averages.FTA)) * 100,1),
                HollingerAssistRatio = (float)Math.Round(averages.AST / (averages.TwoPA + averages.ThreePA + 0.475f * averages.FTA + averages.AST + averages.TOV) * 100,1)
        };
        }

    }

 

}