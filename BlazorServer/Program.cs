using BlazorServer.Components;
using BlazorServer.Models;
using BlazorServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<DetalleDiarioService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<RutaColoniaService>();
builder.Services.AddScoped<TipoUnidadService>();
builder.Services.AddScoped<UnidadService>();

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
