using AppBlazor.Client;
using AppBlazor.Client.Services;
using AppBlazor.Entities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<TipoLibroService>();
builder.Services.AddScoped<JefeService>();
builder.Services.AddScoped<ClienteService>(sp =>
{
    var libroService = sp.GetRequiredService<LibroService>();
    return new ClienteService(libroService);
});
builder.Services.AddScoped<SucursalService>(sp =>
{
    var libroService = sp.GetRequiredService<LibroService>();
    return new SucursalService(libroService);
});
await builder.Build().RunAsync();
