using MULTISHOP.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ContextEMultishop>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllerRoute("areas", "{area:exists}/{controller=Category}/{action=Index}/{id?}");

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();