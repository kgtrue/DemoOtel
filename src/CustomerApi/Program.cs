using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Common.Tracing;
using CustomerApp;
using CustomerAppImplementation;
using CustomerApp.Customers.CreateCustomer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string serviceName = "Customer-Api";
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
builder.Services.AddCustomerApplication();
builder.Services.AddCustomerInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.Services.GetRequiredService<ICustomerDbContext>().Migrate();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var tracer = app.Services.GetRequiredService<Tracer>();
using var span = tracer.StartActiveSpan($"SayHello {serviceName}");

app.MapPost("/customers/", async (ICreateCustomerCommand command, CreateCustomerRequest request, CancellationToken cancellationToken) =>
{
    var result = await command.CreateCustomer(request, cancellationToken);
    return Results.Ok(result);

}).WithName("Customers")
.WithOpenApi();

app.Run();
