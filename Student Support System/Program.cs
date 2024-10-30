using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentSupportSystem.Service.Implement;
using StudentSupportSystem.Service.Interface;
using StudentSupportSystem.ViewModel;
using StudentSupportSystem;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register root components for the Blazor app
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Conditional base address for HttpClient depending on build configuration
#if DEBUG
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.10.220") });
#else
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
#endif

// Register services for dependency injection
builder.Services.AddScoped<IHttpClientService, HttpClientService>(); // Adjusted to scoped
builder.Services.AddScoped<BaseViewModel>();
builder.Services.AddScoped<StudentSupportMasterViewModel>();
builder.Services.AddScoped<CreareStudentSupportMasterViewModel>();
builder.Services.AddSingleton<IDialogService>(d =>
{
    var js = d.GetRequiredService<IJSRuntime>()!;
    return new DialogService(js);
});

// Build and run the app
await builder.Build().RunAsync();
