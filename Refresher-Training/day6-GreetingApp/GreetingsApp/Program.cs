var builder = WebApplication.CreateBuilder(args);

// Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Show error page outside development
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Allow CSS, JavaScript and images
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Default route: Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Start the app
app.Run();