using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Student_Support_System.Service.Implement;
using Student_Support_System.Service.Interface;
using Student_Support_System.ViewModel;
using Student_Support_System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register root components for the Blazor app
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Conditional base address for HttpClient depending on build configuration
#if DEBUG
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://192.168.1.41") });
#else
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
#endif

// Register services for dependency injection
builder.Services.AddScoped<IHttpClientService, HttpClientService>(); // Adjusted to scoped
builder.Services.AddSingleton<BaseViewModel>();
builder.Services.AddScoped<StudentSupportMasterViewModel>();
builder.Services.AddScoped<CreareStudentSupportMasterViewModel>();

// Build and run the app
await builder.Build().RunAsync();
