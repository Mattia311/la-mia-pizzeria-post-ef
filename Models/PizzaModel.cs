using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace la_mia_pizzeria_post_ef.Models
{ [Table("pizza")]
    public class PizzaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il nome della pizza è obbligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descrizione della pizza è obbligatoria")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio")]
        public double Price { get; set; }
        public string? Photo { get; set; }

        public PizzaModel(string Nome, string Descizione, double Prezzo, string Foto)
        {
            //this.Id = id;
            this.Name = Nome;
            this.Description = Descizione;
            this.Price = Prezzo;
            this.Photo = Foto;
        }
        public PizzaModel()
        { }
    }

   /* using (;PizzaContext db = new PizzaContext())
        {

        };*/
}
