namespace la_mia_pizzeria_post_ef.Models
{
    public class PizzasList
    {
        public List<PizzaModel> pizzas { get; set; }

        public PizzasList()
        {
            pizzas = new List<PizzaModel>();
        }

    }
}
