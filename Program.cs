using Microsoft.EntityFrameworkCore;
using PrototypProjekta.Models;
using PrototypProjekta.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();





//to my musieliśmy dodać

builder.Services.AddDbContext<AppDbContext>(
options => options.UseSqlServer(builder.Configuration["Data:Connection"]));

builder.Services.AddScoped<ISneakerRepository, EFSneakerRepository>();







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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
