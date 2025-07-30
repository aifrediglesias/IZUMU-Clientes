using IzumuWeb.Interfaces;
using IzumuWeb.Model.Implementations;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Configura Kestrel para escuchar en HTTP y HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // HTTP
    options.ListenAnyIP(443, listenOptions =>
    {
        listenOptions.UseHttps(); // Usa certificados montados si los hay
    });
});

// Add services to the container.
builder.Services.AddTransient<ICustomerModel, CustomerModel>();
builder.Services.AddTransient<IPlanModel, PlanModel>();
builder.Services.AddTransient<IDocumentTypeModel, DocumentTypeModel>();
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"/keys/"))
    .SetApplicationName("IzumuApp");

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
