using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapGet("/recordeddailytemperature", () =>
{
    var temperatureService = new DailyTemperatureService();
    return temperatureService.GenerateTemperatureRecs().ToArray();
})
.WithName("recordeddailytemperature");

app.MapGet("/dailytemperature", () =>
{
    var temperatureService = new DailyTemperatureService();
    return temperatureService.GenerateTemperature().ToArray();
})
.WithName("dailytemperature");

app.MapGet("/newendpoint", () =>
{
    return "Hello world!";
})
.WithName("newendpoint");

app.Run();
