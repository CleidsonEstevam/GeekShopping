using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Initializer;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region "Config StringConnection"
var connection = builder.Configuration["MySqlConnection:MysqlConnectionString"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25))));
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbInitializer, Initializer>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MySqlContext>()
    .AddDefaultTokenProviders();

var bld = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;

}).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResource)
   .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
   .AddInMemoryClients(IdentityConfiguration.Clients)
   .AddAspNetIdentity<ApplicationUser>();



bld.AddDeveloperSigningCredential();

var app = builder.Build();
var dbInitializeService = app.Services.CreateScope().ServiceProvider.GetService<IDbInitializer>();

// Configure the HTTP request pipeline.


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

dbInitializeService.Initializer();

app.Run();
