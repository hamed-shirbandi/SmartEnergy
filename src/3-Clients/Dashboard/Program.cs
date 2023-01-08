using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SmartEnergy.Clients.Dashboard;
using SmartEnergy.Clients.Dashboard.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.ConfigureServices(builder.Configuration);

await builder.Build().RunAsync();
