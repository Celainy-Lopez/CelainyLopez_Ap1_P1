using CelainyLopez_Ap1_P1.Components;
using CelainyLopez_Ap1_P1.DAL;
using CelainyLopez_Ap1_P1.Models;
using CelainyLopez_Ap1_P1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Context>(o => o.UseSqlite(ConStr));

builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<DeudorService>();
builder.Services.AddScoped<CobroService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
