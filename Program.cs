using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using interactive_cv_blazor;
using interactiveCvBlazor.Services;
using interactiveCvBlazor.Store;
using Radzen;
using Serilog;
using TG.Blazor.IndexedDB;

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

builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "CvBlanquetLaurent"; 
    dbStore.Version = 1; 
    
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "presentation", 
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "title", KeyPath = "title", Unique = false },
            new IndexSpec { Name = "description", KeyPath = "description", Unique = false },
            new IndexSpec { Name = "profil", KeyPath = "profil", Unique = false },
            new IndexSpec { Name = "name", KeyPath = "address.name", Unique = false },
            new IndexSpec { Name = "street", KeyPath = "address.street", Unique = false },
            new IndexSpec { Name = "city", KeyPath = "address.city", Unique = false },
            new IndexSpec { Name = "telephone", KeyPath = "address.telephone", Unique = false },
            new IndexSpec { Name = "email", KeyPath = "address.email", Unique = false },
        ]
    });
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "version", 
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "number", KeyPath = "number", Unique = false },
            new IndexSpec { Name = "date", KeyPath = "date", Unique = false }
        ]
    });
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "experiences", 
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "society.name", KeyPath = "society.name", Unique = false },
            new IndexSpec { Name = "society.url", KeyPath = "society.url", Unique = false },
            new IndexSpec { Name = "job", KeyPath = "job", Unique = false },
            new IndexSpec { Name = "startYear", KeyPath = "startYear", Unique = false },
            new IndexSpec { Name = "endYear", KeyPath = "endYear", Unique = false },
            new IndexSpec { Name = "description", KeyPath = "description", Unique = false },
            new IndexSpec { Name = "tags.label", KeyPath = "tags.label", Unique = false },
            new IndexSpec { Name = "tags.tag", KeyPath = "tags.tag", Unique = false }
        ]
    });   
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "skills", 
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "title", KeyPath = "title", Unique = false },
            new IndexSpec { Name = "content.name", KeyPath = "content.name", Unique = false },
            new IndexSpec { Name = "content.level", KeyPath = "content.level", Unique = false },
            new IndexSpec { Name = "content.label", KeyPath = "content.label", Unique = false }
        ]
    });     
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "trainings", 
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "title", KeyPath = "title", Unique = false },
            new IndexSpec { Name = "period", KeyPath = "period", Unique = false },
            new IndexSpec { Name = "spec", KeyPath = "spec", Unique = false }
        ]
    });     
    dbStore.Stores.Add(new StoreSchema
    {
        Name = "howtos", 
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes =
        [
            new IndexSpec { Name = "qualities", KeyPath = "qualities", Unique = false },
            new IndexSpec { Name = "defaults", KeyPath = "defaults", Unique = false }
        ]
    });       
    
});

builder.Services.AddScoped<GlobalState>();
builder.Services.AddSingleton(Log.Logger);

await builder.Build().RunAsync();