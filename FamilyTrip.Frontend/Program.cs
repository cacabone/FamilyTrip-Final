using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FamilyTrip.Frontend;
using FamilyTrip.Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Use API base address in development, Blazor base address in production
#if DEBUG
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7163/") }); // Matches API launchSettings.json
#else
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
#endif
builder.Services.AddScoped<FamilyService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TripService>();
builder.Services.AddScoped<PackingListService>();

await builder.Build().RunAsync();
