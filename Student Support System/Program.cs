using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentSupportSystem.Service.Implement;
using StudentSupportSystem.Service.Interface;
using StudentSupportSystem.ViewModel;
using StudentSupportSystem;
using Microsoft.JSInterop;
using StudentSupportSystem.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register root components for the Blazor app
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Conditional base address for HttpClient depending on build configuration
#if DEBUG
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.252.243") });
#else
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://192.168.10.220") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
#endif

// Register services for dependency injection
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddScoped<IStudentSupportMasterService, StudentSupportMasterService>();

builder.Services.AddScoped<BaseViewModel>();
builder.Services.AddScoped<StudentSupportMasterViewModel>();
builder.Services.AddTransient<ModalAddCommitCrimeStdViewModel>();
builder.Services.AddTransient<ModalHistoryCommitCrimeStdViewModel>();
builder.Services.AddTransient<ProfileStudentSupportMasterViewModel>();

builder.Services.AddSingleton<IDialogService>(d =>
{
    var js = d.GetRequiredService<IJSRuntime>()!;
    return new DialogService(js);
});
builder.Services.AddSingleton<ILoadingService>(d =>
{
    var js = d.GetRequiredService<IJSRuntime>()!;
    return new LoadingService(js);
});

//builder.Services.AddSingleton<StudentSupportMaster>();

// Build and run the app
await builder.Build().RunAsync();