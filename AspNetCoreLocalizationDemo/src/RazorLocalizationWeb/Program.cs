using RazorLocalizationWeb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddLocalizationService();

// Add controller support
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Enable the localization middleware using the UseRequestLocalization method.
app.UseRequestLocalization();

app.MapRazorPages();

app.MapControllers();

app.Run();
