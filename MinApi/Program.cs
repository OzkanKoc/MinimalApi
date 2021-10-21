using MinApi.EndpointsDescribers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MinApi.Api", Version = "v1" });
});

builder.Services.AddEndpointDefinitions();

await using var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MinApi.Api v1");
    c.RoutePrefix = "";
});

app.UseEndpointDefinitions();

await app.RunAsync();