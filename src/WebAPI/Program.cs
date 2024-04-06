using Application.DailyTemperature.Commands.CreateDailyTemperature;
using Application.DailyTemperature.Queries.GetRecordedDailyTemperatures;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    .RequireAuthenticatedUser()
    .Build();
});
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey, 
        Scheme = "Bearer" 
    });

    // Add the Bearer token authentication requirement to all operations
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer", 
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/dailytemperatures", async (IMediator mediator) =>
    await mediator.Send(new GetDailyTemperatureQuery()) is var items
        ? Results.Ok(items)
        : Results.NotFound())
    .WithName("getDailyTemperatures")
    .Produces<IEnumerable<DailyTemperatureDto>>()
    .AllowAnonymous();

app.MapPost("/dailytemperatures", async (CreateDailyTemperatureCommand command, IMediator mediator) =>
{
    var createdTemperatureId = await mediator.Send(command);
    var uri = $"/dailytemperatures/{createdTemperatureId}";
    return Results.Created(uri, new { Id = createdTemperatureId });
})
    .WithName("createDailyTemperature")
    .AllowAnonymous();

app.Run();
