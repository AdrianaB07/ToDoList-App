using Microsoft.EntityFrameworkCore;
using ToDoListApp.Data; // Import? namespace-ul unde ai ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Adaug? serviciul DbContext cu SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adaug? serviciile MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configureaz? pipeline-ul HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
