using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using System.Configuration;
using WebPetProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Build.Framework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Host.UseDefaultServiceProvider(options =>
    options.ValidateScopes = false);

string? connection = builder.Configuration.GetConnectionString("SportStoreProducts");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddTransient<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
var app = builder.Build();

app.UseSession();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.MapControllerRoute(
    name: null,
    pattern: "{category}/Page{productPage:int}",
    defaults: new { controller = "Product", action = "List" }
);
app.MapControllerRoute(
    name: null,
    pattern:"Page{productPage:int}",
    defaults: new { controller = "Product",action="List",productPage=1}
);
app.MapControllerRoute(
    name:null,
    pattern:"{category}",
    defaults: new {controller = "Product", action = "List", productPage = 1}
);
app.MapControllerRoute(
    name: null,
    pattern: "",
    defaults: new { controller = "Product", action = "List", productPage = 1 }
);
app.MapControllerRoute(
    name: null,
    pattern: "{controller}/{action}/{id?}"
);

SeedData.EnSurePopilated(app);
app.Run();
