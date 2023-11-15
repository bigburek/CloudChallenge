using CloudChallenge;
using CloudChallenge.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Xunit;

public class PlayerStatsControllerTests
{
    [Fact]
    public void GetPlayerStats_ReturnsOkResult()
    {
        var loggerMock = new Mock<ILogger<PlayerStatsController>>();
        var controller = new PlayerStatsController(loggerMock.Object);

        // Simulate having a player with the specified full name in the test data
        var testPlayer = new PlayersInput { Player = "Test Player" };
        PlayerData.playersData = new List<PlayersInput> { testPlayer };

        // Act
        var result = controller.GetPlayerStats("Test Player");

        // Assert
        Assert.IsType<OkObjectResult>(result);

        //The test succeeds if any (testPlayer) is found
    }
    [Fact]
    public void GetPlayerStats_ReturnsOkResultWithCorrectData()
    {
        var loggerMock = new Mock<ILogger<PlayerStatsController>>();
        var controller = new PlayerStatsController(loggerMock.Object);

        // Simulate having a player with the specified full name in the test data
        var testPlayer = new PlayersInput { Player = "Test Player" };
        PlayerData.playersData = new List<PlayersInput> { testPlayer };

        // Act
        var result = controller.GetPlayerStats("Test Player") as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<PlayerStats>(result.Value);
    }
    [Fact]
    public void GetPlayerStats_ReturnsNotFoundResultForUnknownPlayer()
    {
        var loggerMock = new Mock<ILogger<PlayerStatsController>>();
        var controller = new PlayerStatsController(loggerMock.Object);

        // Act
        var result = controller.GetPlayerStats("Nonexistent Player");

        // Assert
        Assert.IsType<NotFoundObjectResult>(result); //It will return a NotFoundObjectResult response no matter what the error user makes
    }

}
