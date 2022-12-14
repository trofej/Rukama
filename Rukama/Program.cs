using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rukama.Areas.Identity.Data;
using Rukama.Data;
using Rukama.Infrastructure;
using Rukama.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AuthDbContextConnection' not found.");

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthDbContext>();

// Add services for the identity (avatar upload when register)
builder.Services.AddIdentityCore<User>()
.AddRoles<IdentityRole>()
.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, IdentityRole>>()
.AddEntityFrameworkStores<AuthDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

// Add IUnitOfWork + UnitOfWork (avatar upload when register)

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Add IUnitOfWork for Avatar image
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
app.UseAuthentication();;

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
