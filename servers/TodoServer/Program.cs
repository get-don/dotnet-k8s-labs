using TodoServer.Config;
using TodoServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddSingleton<AppState>();
builder.Services.AddHostedService<AppInitializer>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "api");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
