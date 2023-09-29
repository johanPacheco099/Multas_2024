using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Multas.Data;
using Multas.Shared.Services;
using Multas.Shared.Services.SCoactivo;
using Multas.Shared.Services.SInteres;
using Multas.Shared.Services.SLiquidacion;
using Multas.Shared.Services.SUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IComparendoService , ComparendoService>();
builder.Services.AddScoped<ILiquidacionService , LiquidacionService>();
builder.Services.AddScoped<IInteresService , InteresService>();
builder.Services.AddScoped<ICoactivoService , CoactivoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
