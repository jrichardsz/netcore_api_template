using Src.Database;
using Src.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Datasource>(_ => new Datasource(
    System.Environment.GetEnvironmentVariable("DATABASE_CONNECTION")));
builder.Services.AddTransient<IMovieRepository, MovieRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")=="Development")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();