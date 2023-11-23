using CustomerApp;
using CustomerAppImplementation;
using CustomerApp.Customers.CreateCustomer;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomerApplication();
builder.AddCustomerInfrastructure();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<CustomerDbContext>().Migrate();

app.UseHttpsRedirection();


app.MapPost("/customers/", async (ICreateCustomerCommand command, CreateCustomerRequest request, CancellationToken cancellationToken) =>
{
    var result = await command.CreateCustomer(request, cancellationToken);
    return Results.Ok(result);

}).WithName("Customers")
.WithOpenApi();

app.Run();
