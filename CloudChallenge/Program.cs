using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using CloudChallenge;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 
//Getting the csv file
string filename = "L9HomeworkChallengePlayersInput.csv";
string workingDirectory = Directory.GetCurrentDirectory();
string filePath = Path.Combine(workingDirectory, "data", filename);
//Reading the csv file in to the list
PlayerData.playersData = ReadCsvFile<PlayersInput>(filePath);


PlayersInput ab = new PlayersInput
{
    Player = "John Doe",
    Position = "Guard",
    FreeThrowsMade = 10,
    FreeThrowsAttempted = 15,
    TwoPointMade = 20,
    TwoPointAttempted = 30,
    ThreePointMade = 5,
    ThreePointAttempted = 10,
    Rebounds = 8,
    Blocks = 2,
    Assists = 12,
    Steals = 4,
    Turnovers = 6
};

PlayerData.playersData.Add(ab);

app.Run();


List<T> ReadCsvFile<T>(string filePath)
{
    try
    {
        //Checking if file exists
        if (!File.Exists(filePath))
        {
            app.Logger.LogCritical($"File not found: {filePath}");
            return new List<T>();
        }
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<T>().ToList(); //Using the CsvHelper library
        }
    }
    catch(Exception e) {app.Logger.LogCritical($"Exception: {e}");}
    return new List<T>();
}