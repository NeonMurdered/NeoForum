using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeoForum.Areas.Identity.Data;
using NeoForum.Data;
using NeoForum.Hubs;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NeoForumDbContextConnection") ?? throw new InvalidOperationException("Connection string 'NeoForumDbContextConnection' not found.");

builder.Services.AddDbContext<NeoForumDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<NeoForumUser>(options => { options.SignIn.RequireConfirmedAccount = false; options.Password.RequireUppercase = false; options.Password.RequireNonAlphanumeric = false; })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<NeoForumDbContext>();

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapHub<ChatHub>("/Home/Index");
app.Run();
