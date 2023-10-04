using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using System.Configuration;
using WebPetProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Host.UseDefaultServiceProvider(options =>
    options.ValidateScopes = false);

string? connection = builder.Configuration.GetConnectionString("SportStoreProducts");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddTransient<IProductRepository, EFProductRepository>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();


app.MapControllerRoute(
            name: "pagination",
            pattern: "Products/Page{productPage}",
            defaults: new { Controller = "Product", action = "List" }
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");
SeedData.EnSurePopilated(app);
app.Run();
