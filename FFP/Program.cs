using FFP.Context;
using FFP.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injetando dependencias
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<ITimeService, TimeService>();
builder.Services.AddScoped<IJogadorService, JogadorService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

#region Seeding Service

app.Services.CreateScope()
    .ServiceProvider
    .GetRequiredService<SeedingService>().Seed(); // Forma no .NET 6 ou 7 para popular o DB com o seeding service
#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
