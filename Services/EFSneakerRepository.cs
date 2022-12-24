using PrototypProjekta.Models;
using Microsoft.EntityFrameworkCore;

namespace PrototypProjekta.Services
{

    //Implementacja repozytorium zdostęmpem do Bazy - Implemetacja tylko metody dostępu do funkcji
    public class EFSneakerRepository : ISneakerRepository
    {
        private readonly AppDbContext _context;

        public EFSneakerRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(int? id)
        {
            if (id is null)
            {
                return false;
            }

            var find = _context.sneakerModels.Find(id);
            if (find is not null)
            {
                _context.sneakerModels.Remove(find);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SneakerModel> FindAll()
        {
            return _context.sneakerModels.ToList();
        }

        public int Save(SneakerModel sneakerModel)
        {
            try
            {
                var entityEntry = _context.sneakerModels.Add(sneakerModel);
                _context.SaveChanges();
                return entityEntry.Entity.Id;
            }
            catch
            {
                return -1;
            }
        }
    }
}
