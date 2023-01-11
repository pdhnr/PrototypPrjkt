using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrototypProjekta.Models
{
    //AppDbContext - zamienia naszą klasse w tabele i wrzuca w TSQL
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        ////////////////////////////////////////////////////////////////////////////
        //Encja - to klasa, ktora objekty zapisany w BD
        //Encji:
        public DbSet<SneakerModel> sneakerModels { get; set; } //tworzy nam tablice.

        public DbSet<CategoryModel> categoryModels { get; set; }



        /*
          Klasa staje się encją  - jesli zostanie dodana do zbioru  w kontekscie ((np.) w AppDbContext:)
          i była wrzucona w ((np.)DbSet<> ... {get; set;}) : 

        
                    public DbSet<SneakerModel> sneakerModels { get; set; }
         */



        /////////////////////////////////////////////////////////////////////
        //Usuwania Cascadowe
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CategoryModel>()
                .HasOne(e => e.SneakerModel)
                .WithOne(e => e.CategoryModel)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder
                .Entity<SneakerModel>()
                .HasOne(e => e.CategoryModel)
                .WithOne(e => e.SneakerModel)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        /////////////////////////////////////////////////////////////////////

    }


}
