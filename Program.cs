using CapstoneGenerator.Server.Services.Contracts;
using CapstoneGenerator.Server.Services;
using CapstoneGenerator.Server.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using CapstoneGenerator.Server.Repositories.Contracts;
using CapstoneGenerator.Server.Repositories;
using CapstoneGenerator.Server.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<WebApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<ICapstoneServices, CapstoneService>();

// Repositories
builder.Services.AddScoped<ICapstoneRepository, CapstoneRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
        {
            policy.WithOrigins("https://localhost:5225")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddSignalR();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");
app.UseWebSockets();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapHub<CapstoneHub>("/capstonehub");

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
