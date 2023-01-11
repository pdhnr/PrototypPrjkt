using Microsoft.Extensions.Hosting;
using PrototypProjekta.Models;

namespace PrototypProjekta.Services
{
    //interfejs Repozitory - udostepnia 1 tabelę z funkcjami
    public interface ISneakerRepository //uwaga zmień zamiast CLASS na INTERFACE
    {
        public int Save(SneakerModel sneakerModel);

        public bool Delete(int? id);

        public int Update(SneakerModel sneakerModel);

        public SneakerModel? FindBy(int? id);

        public void ChangeCategorySneaker(CategoryModel categoryModel, int? id);

        public ICollection<SneakerModel> FindAll();
    }
}
