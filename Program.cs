using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using interactive_cv_blazor;
using interactiveCvBlazor.Services;
using Radzen;
using Serilog;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRadzenComponents();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.BrowserConsole()
    .CreateLogger();


builder.Services.AddHttpClient<DataService>(client =>
{
    client.BaseAddress = new Uri("https://cohaagen.proxydns.com/services/datasCV/");
});
builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddFluxor(options =>
{
    options.ScanAssemblies(typeof(Program).Assembly);
});

builder.Services.AddSingleton(Log.Logger);

await builder.Build().RunAsync();