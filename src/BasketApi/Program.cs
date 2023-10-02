using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Common.Tracing;
using BasketApp;
using BasketAppImplementation;
using MediatR;
using BasketApp.Baskets.CreateBasket;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string serviceName = "Basket-Api";
const string serviceVersion = "1";

builder.Services.AddOpenTelemetry()
  .WithTracing(b =>
  {
      b
      .AddConsoleExporter()
      .AddOtlpExporter(config => { config.Endpoint = new Uri("http://jaeger:4317"); })
      .AddAspNetCoreInstrumentation()
      .AddSource(serviceName)
      .ConfigureResource(resource =>
          resource.AddService(
            serviceName: serviceName,
            serviceVersion: serviceVersion));
  });

builder.Services.SetupActivitySource(serviceName, serviceVersion);
builder.Services.AddBasketApplication();
builder.Services.AddBasketInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var tracer = app.Services.GetRequiredService<Tracer>();
using var span = tracer.StartActiveSpan($"SayHello {serviceName}");

app.MapPost("/baskets/", async (IMediator mediator, CreateBasketRequest request) =>
{
    var basket = await mediator.Send(request);
    return Results.Ok(basket);

}).WithName("Baskets")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
