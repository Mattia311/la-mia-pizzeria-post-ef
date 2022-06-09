using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace la_mia_pizzeria_post_ef.Models
{
    [Table("Pizza")]
    public class NuovaPizza
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        public double Price { get; set; }
        public string? Photo { get; set; }

        /*public NuovaPizza(string Nome, string Descizione, double Prezzo, string Foto)
        {

            this.Name = Nome;
            this.Description = Descizione;
            this.Price = Prezzo;
            this.Photo = Foto;
        }*/
        public byte[]? Data { get; set; }

        public NuovaPizza()
        { }
    }
}
