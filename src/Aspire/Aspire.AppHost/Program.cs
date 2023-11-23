var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServerContainer("mssql", "Password!", 1433).AddDatabase("CustomerDatabase");

var basketapi = builder.AddProject<Projects.BasketApi>("basketapi");

var customerapi = builder.AddProject<Projects.CustomerApi>("customerapi")
    .WithReference(sql);

var fulfilmentapi = builder.AddProject<Projects.FulfilmentApi>("fulfilmentapi");

var gatewayapi = builder.AddProject<Projects.GatewayApi>("gatewayapi");

var orderapi = builder.AddProject<Projects.OrderApi>("orderapi");

var productcatalogueapi = builder.AddProject<Projects.ProductCatalogueApi>("productcatalogueapi");

builder.AddProject<Projects.ShopUI>("shopui");

builder.Build().Run();
