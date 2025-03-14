using Microsoft.EntityFrameworkCore;
using Norwind.Api;
using Norwind.Api.Domain.Entities.Interfaces;
using Norwind.Api.Domain.Repositries.Repositries;
using NuGet.Protocol.Plugins;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Connection>(builder.Configuration.GetSection("Connections"));

var OperationConnectionString = builder.Configuration["Connections:OperationConnectionString"];
builder.Services.AddDbContext<InstnwndContext>(options => options.UseSqlServer(OperationConnectionString));

builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();


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
