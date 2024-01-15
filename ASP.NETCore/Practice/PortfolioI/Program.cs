using System.Collections.Immutable;
var builder = WebApplication.CreateBuilder(args);

// add services 

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name : "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"

);

app.Run();
