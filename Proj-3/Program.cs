using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Proj_3.DataBase;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("Default")!);
builder.Services.AddDbContext<DbServices>(options =>
    options.UseMySQL(
        builder.Configuration.GetConnectionString("Default")!
    )
);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
//object value = builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
