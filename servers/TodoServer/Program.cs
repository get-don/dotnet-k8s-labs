using TodoServer.Config;
using TodoServer.Middlewares;
using TodoServer.Repository;
using TodoServer.Repository.IRepository;
using TodoServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddSingleton<AppState>();
builder.Services.AddHostedService<AppInitializer>();

builder.Services.AddScoped<ITodosRepository, TodosRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "api");
    });
}

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
