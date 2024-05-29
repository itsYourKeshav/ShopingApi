using Microsoft.EntityFrameworkCore;
using ShopingApi.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EF_DataContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DbConnectionPgSql"))
    );

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
