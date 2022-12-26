using Microsoft.EntityFrameworkCore;
using System;

namespace PrototypProjekta.Models
{
    //AppDbContext - zamienia naszą klasse w tabele i wrzuca w TSQL
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        //Encja - to klasa, ktora objekty zapisany w BD
        //Encja
        public DbSet<SneakerModel> sneakerModels { get; set; } //tworzy nam tablice.



        /*
          Klasa staje się encją  - jesli zostanie dodana do zbioru  w kontekscie : 

                    (np.) w AppDbContext:
        
                    public DbSet<SneakerModel> sneakerModels { get; set; }
         */

    }


}
