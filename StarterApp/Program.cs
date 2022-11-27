using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarterApp.Data;
using StarterApp.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("Assembly name: "+ Assembly.GetExecutingAssembly().FullName);

/* if(builder.Environment.IsDevelopment())
{ */
    builder.Services.AddDbContext<SomeDbContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("SomeDbContext") ?? 
            throw new InvalidOperationException(
                "DEV Connection string 'SomeDbContext' not found.")));
    
    // Post-ID-Scaffold
    builder.Services.AddDbContext<SomeIdDbContext>(options =>
        options.UseSqlite(
            builder.Configuration.GetConnectionString("SomeIdDbContextConnection") ?? 
            throw new InvalidOperationException(
                "DEV Connection string 'SomeIdDbContextConnection' not found.")));
/* }
else
{
    builder.Services.AddDbContext<SomeDbContext>(
        options => options.UseSqlServer(
            builder.Configuration
                .GetConnectionString("ProductionSomeDbContext") ?? 
            throw new InvalidOperationException(
                "PROD Connection string 'SomeDbContext' not found.")
        )
    );

    // TODO Add something for the IdDbContext for PROD
} */

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SomeIdDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    // The default HSTS value is 30 days. You may want to change this for 
    // production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
