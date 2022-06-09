using la_mia_pizzeria_post_ef.Models;
using Microsoft.AspNetCore.Mvc;

//Ciao ragazzi, andiamo avanti con l'applicazione per gestire la nostra pizzeria.
//Lo scopo di oggi è quello di rendere dinamici i contenuti che abbiamo come html statico nella pagina con la lista delle pizze.
//Creiamo prima un nostro controller chiamato PizzaController e utilizziamo lui d'ora in avanti.
//L'elenco delle pizze ora va passato come model dal controller, e la view deve utilizzarlo per mostrare l'html corretto.
//Gestiamo anche la possibilità che non ci siano pizze nell'elenco:
//in quel caso dobbiamo mostrare un messaggio che indichi all'utente che non ci sono pizze presenti nella nostra applicazione.
//Ogni pizza dell'elenco avrà un pulsante che se cliccato ci porterà a una pagina che mostrerà i dettagli di quella singola pizza.
//Dobbiamo quindi inviare l'id come parametro dell'URL, recuperarlo con la action, caricare i dati della pizza ricercata e passarli come model.
//La view a quel punto li mostrerà all'utente con la grafica che preferiamo.
//Ps. visto che abbiamo cambiato il controller sul quale lavoriamo, ricordiamoci di cambiare anche il "mapping di default" dei controller, altrimenti quale pagina viene caricata se richiamo l'url "/" della nostra webapp?


namespace la_mia_pizzeria_post_ef.Controllers
{
    public class PizzaController : Controller
    {
        public static PizzasList pizze;

        public static PizzaContext db = new PizzaContext();

        public IActionResult Index()
        {
            PizzaModel Margherita = new PizzaModel("Margherita", "Pomodori ramati 180 g, Mozzarella 220 g, Prosciutto cotto 200 g, Olio extravergine d'oliva 2 cucchiai, Sale q.b, Pepe q.b., Olive verdi 50 g", 6.50, "img/1.jfif");
            PizzaModel Salsiccia = new PizzaModel("Salsiccia", "Pomodori ramati 180 g, Mozzarella 220 g, Prosciutto cotto 200 g, Olio extravergine d'oliva 2 cucchiai, Sale q.b, Pepe q.b., Olive verdi 50 g", 7.50, "img/2.jfif");
            PizzaModel Marinara = new PizzaModel("Marinara", "Pomodori ramati 180 g, Mozzarella 220 g, Prosciutto cotto 200 g, Olio extravergine d'oliva 2 cucchiai, Sale q.b, Pepe q.b., Olive verdi 50 g", 7.00, "img/3.jfif");
            PizzaModel Patatine = new PizzaModel("Patatine", "Pomodori ramati 180 g, Mozzarella 220 g, Prosciutto cotto 200 g, Olio extravergine d'oliva 2 cucchiai, Sale q.b, Pepe q.b., Olive verdi 50 g", 8.50, "img/4.jfif");
            PizzaModel Salame = new PizzaModel("Salame", "Pomodori ramati 180 g, Mozzarella 220 g, Prosciutto cotto 200 g, Olio extravergine d'oliva 2 cucchiai, Sale q.b, Pepe q.b., Olive verdi 50 g", 8.00, "img/5.jfif");
            PizzaModel Cotto = new PizzaModel("Cotto", "Pomodoro, origano, alici di Cetara, burratina", 9.50, "img/1.jfif");

            pizze = new();
            pizze.pizzas.Add(Margherita);
            pizze.pizzas.Add(Salsiccia);
            pizze.pizzas.Add(Marinara);
            pizze.pizzas.Add(Patatine);
            pizze.pizzas.Add(Salame);
            pizze.pizzas.Add(Cotto);

            db.Add(Margherita);
            db.Add(Salsiccia);
            db.Add(Marinara);
            db.Add(Patatine);
            db.Add(Salame);
            db.Add(Cotto);
            db.SaveChanges();


            return View(pizze);
        }


       

        public IActionResult Show(PizzaModel pizza)
        {

            return View("Show", pizza);
        }
        public IActionResult CreaNuovaPizza()
        {
            PizzaModel NuovaPizza = new PizzaModel()
            {
                Name = "",
                Description = "",
                Price = 0.0,
                Photo = "",

            };

            return View(NuovaPizza);
        }


        public IActionResult ShowPizza(PizzaModel pizza)
        {

            if (!ModelState.IsValid)
            {
                return View("CreaNuovaPizza", pizza);
            }

            PizzaModel nuovaPizza = new PizzaModel()
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Price = pizza.Price,
                Photo = pizza.Photo,

            };
            db.Add(nuovaPizza);
            db.SaveChanges();
            return View("ShowPizza", nuovaPizza);
        }


        public IActionResult AggiornaPizza(PizzaModel pizza)
        {

            return View("AggiornaPizza", pizza);
        }

        public IActionResult EditPizza(PizzaModel pizza)
        {
            PizzaModel updatePizza = new PizzaModel();


            if (pizza != null)
            {

                updatePizza = db.Pizzas.Find(pizza.Id);

                updatePizza.Name = pizza.Name;
                updatePizza.Description = pizza.Description;
                updatePizza.Price = pizza.Price;
                if (updatePizza.Photo != pizza.Photo)
                {
                    updatePizza.Photo = pizza.Photo;
                }
                db.Update(updatePizza);
                db.SaveChanges();
            }


            return View("Show", updatePizza);
        }




        public IActionResult RimuoviPizza(PizzaModel pizza)
        {
            return View("RimuoviPizza", pizza);
        }



        [HttpPost]
        public IActionResult Delete(PizzaModel pizza)
        {
            PizzaModel updatePizza = db.Pizzas.Find(pizza.Id);

            if (updatePizza.Id == pizza.Id)
            {
                db.Remove(updatePizza);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
