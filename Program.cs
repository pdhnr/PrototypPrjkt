using Microsoft.EntityFrameworkCore;
using PrototypProjekta.Models;
using PrototypProjekta.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();





////////////////////////////////////////////////////////////////////////////////

//to my musieliśmy dodać

builder.Services.AddDbContext<AppDbContext>(
options => options.UseSqlServer(builder.Configuration["Data:Connection"]));

builder.Services.AddScoped<ISneakerRepository, EFSneakerRepository>();

////////////////////////////////////////////////////////////////////////////////






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

app.UseRouting(); //ta komenda zeby włączyc Routing 

app.UseAuthorization();


/*
Routing / Trasowanie / Маршутизація - wążanie odpowiedniej sciezki z metodą akcji
(np. link; localhost: 3000 / produkt / opis / laptop.html)
*/
//formatowanie - endpointów 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*
 Obowązkowo musi być w URL:  ... /Controller/Metoda
                             ... /Controller/Metoda/Id
                             ... /

(np.)

https //Localhost:500/Home/Index
https //Localhost:500/Home/Index/5
https //Localhost:500/             - domyslnie jest (Home/Index)
 */

//Ale nie mozemy urzywac BEZ METODY

app.Run();
