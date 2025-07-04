using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

var gameStoreAPIUrl = builder.Configuration["GameStoreApiUrl"] ?? throw new Exception("GameStore API URL is missing.");

builder.Services.AddHttpClient<GamesClient>(client =>
    client.BaseAddress = new Uri(gameStoreAPIUrl));

builder.Services.AddHttpClient<GenresClient>(client =>
    client.BaseAddress = new Uri(gameStoreAPIUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapStaticAssets();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
