using PracticodeProject3.Service.Interfaces;
using PracticodeProject3.Service.Services;
using PracticodeProject3.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddGitHubIntegration(Options=>builder.Configuration.GetSection(nameof(GithubIntegrationOptions)).Bind(Options));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
