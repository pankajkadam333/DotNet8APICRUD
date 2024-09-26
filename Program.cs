using DotNet8API.AppDataContext;
using DotNet8API.Model;
using DotNet8API.services;
using System.Runtime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IOurHeroService, OurHeroService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add  This to in the Program.cs file
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  // Add this line
// Add  This to in the Program.cs file
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("DbSettings")); // Add this line
builder.Services.AddSingleton<AppDbContext>(); // Add this line

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
