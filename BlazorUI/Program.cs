using BlazorUI.Components;
using MudBlazor.Services;
using Syncfusion.Blazor;
using Syncfusion.Licensing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClient as a singleton or scoped service
builder.Services.AddHttpClient();

builder.Services.AddMudServices();


// builder.Services.AddSyncfusionBlazor(options => {
//     // Register Syncfusion license key (Replace with your actual key)
//     Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmpCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXlceHVVRWVZV0RyXko=");
// });

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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