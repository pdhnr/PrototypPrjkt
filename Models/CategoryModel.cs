using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrototypProjekta.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }//Klucz Glowny


        [Column("Category name")]

        //Adnotacja/walidacja
        [Required(ErrorMessage = "Podaj nazwe rodzaju!")]
        [MaxLength(50, ErrorMessage = "Zadługi tekst! W formularze, może wmieścić się do 50 symbolów.")]
        [MinLength(0, ErrorMessage = "Zakrutki tekst! Musisz wpisać nazwe rodzaju butów.")]
        public string CategoryName { get; set; }



        /////////////////////////////////////////////////////////////////////////
        //Klucz Obcy:
        public int SneakerModelId { get; set; } //Klucz Obcy SneakersModel


        ////////////////////////////////////////////////////////////////////////////
        //Nawigatory:
        public SneakerModel? SneakerModel { get; set; }//Nawigator modele Sneaker

    }
}
