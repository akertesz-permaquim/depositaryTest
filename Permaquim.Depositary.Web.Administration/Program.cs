using BlazorDownloadFile;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddScoped<Radzen.TooltipService>();
builder.Services.AddScoped<Radzen.ContextMenuService>();
builder.Services.AddServerSideBlazor();
builder.Services.AddLocalization();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
builder.Services.AddServerSideBlazor().AddHubOptions(options => { options.MaximumReceiveMessageSize = 10 * 1024 * 1024; });
builder.Services.AddBlazorDownloadFile();

var supportedCultures = new[]
{
    new System.Globalization.CultureInfo("es-AR")
};
//supportedCultures.NumberFormat.NumberDecimalSeparator = ",";
//supportedCultures.NumberFormat.CurrencyDecimalSeparator = ",";
//supportedCultures.NumberFormat.CurrencyGroupSeparator = ".";

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es-AR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("es-AR")
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
