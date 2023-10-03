using GalvantMVC2.Infrastructure;
using GalvantMVC2.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
