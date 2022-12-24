using Microsoft.EntityFrameworkCore;

namespace PrototypProjekta.Models
{
    //AppDbContext - zamienia naszą klasse w tabele i wrzuca w TSQL
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<SneakerModel> sneakerModels { get; set; } //tworzy nam tablice.

    }
}
