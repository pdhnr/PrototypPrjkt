using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrototypProjekta.Models
{

    //Tabela - Klassa
    [Table("Sneaker")]
    public class SneakerModel
    {

        //Obijekt(Pola) - Wiersz 
        [Key]
        public int Id { get; set; }


        //Adnotacja/walidacja
        [Column("Company name")]
        [Required(ErrorMessage = "Podaj nazwe firmy!")]
        [MaxLength(50,ErrorMessage = "Zadługi tekst! W formularze, może wmieścić się do 50 symbolów.")]
        [MinLength(0,ErrorMessage = "Zakrutki tekst! Musisz wpisać nazwe firmy butów.")]
        public string CompanyName { get; set; }


        [Column("Model name")]
        [Required(ErrorMessage = "Podaj nazwe model!")]
        [MaxLength(50, ErrorMessage = "Zadługi tekst! W formularze, może wmieścić się do 50 symbolów.")]
        [MinLength(0, ErrorMessage = "Zakrutki tekst! Musisz wpisać nazwe model butów.")]
        public string ModelName { get; set; }



        [Column("Price")]
        [Required(ErrorMessage = "Proszę podać cenę butów!")]
        [Range(0, 1000000, ErrorMessage = "Proszę podać cenę butów, 0 - 1 000 000!")]
        public double Price { get; set; }

    }
}
