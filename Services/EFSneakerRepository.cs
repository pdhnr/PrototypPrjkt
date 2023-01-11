using PrototypProjekta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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



        //ISave
        public int Save(SneakerModel sneakerModel)
        {
            try
            {
                var entityEntry = _context.sneakerModels.Add(sneakerModel);
                _context.SaveChanges();
                return entityEntry.Entity.SneakerModelId;
            }
            catch
            {
                return -1;
            }
        }



        //IDelete
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


        //IUpdate
        public int Update(SneakerModel sneakerModel)
        {
            try
            {
                var s = _context.sneakerModels.Find(sneakerModel.SneakerModelId);
                if (s is not null)
                {
                    s.SneakerModelId = sneakerModel.SneakerModelId;
                    s.ModelName = sneakerModel.ModelName;
                    s.Price = sneakerModel.Price;
                    s.CompanyName = sneakerModel.CompanyName;
                    s.CategoryModel = sneakerModel.CategoryModel;


                    _context.SaveChanges();
                    return sneakerModel.SneakerModelId;
                }
                return -1;
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }



        //IFindBy
        public SneakerModel? FindBy(int? id)
        {
            return id is null ? null : _context.sneakerModels.Find(id);
        }



        //IChangeCategorySneaker
        public void ChangeCategorySneaker(CategoryModel categoryModel, int? id)
        {
            SneakerModel? sneakerModel = id is null ? null : _context.sneakerModels.Find(id);
            sneakerModel.CategoryModel = categoryModel;
            categoryModel.SneakerModel = sneakerModel;

            _context.sneakerModels.Update(sneakerModel);
            _context.categoryModels.Update(categoryModel);

            _context.SaveChanges();
        }


        /////////////////////////////////////////////////////////////////////////
        //ICollection - .Include(e => e.CategoryModel)
        public ICollection<SneakerModel> FindAll()
        {
            return _context.sneakerModels.Include(e => e.CategoryModel).ToList();//!!! Jezeli tutaj wyskakuje błąd, to usuń eszystkie swoje tabele w SQL, ktore dotyczy twojej bazy.
        }                                                                        //mejsce gdzie znajd się te tabele: w SQL - (np. Databases > [NazwaDataBase] > Tabel )

                                                                                 //Potem zrob migracje jeszcze raz, jezeli nie masz logowania/rejestrowania
                                                                                 //wpisz w konsole:  add-migration [Nazwapliku], (np. add-migration InitialCreate )
                                                                                 //                  update-database

                                                                                 //Jezeli masz logowania/rejestrowania
                                                                                 //wpisz w konsole:  add-migration [Nazwapliku] -context UserContext, (np. add-migration UserInit -context UserContext )
                                                                                 //                  update-database - context UserContext

    }
}
