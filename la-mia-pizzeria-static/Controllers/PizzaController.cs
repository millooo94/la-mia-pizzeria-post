using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using var ctx = new PizzaContext();
            var pizzas = ctx.Pizzas.ToArray();

            return View(pizzas);

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            using var ctx = new PizzaContext();
            var pizza = ctx.Pizzas.SingleOrDefault(p => p.Id == id);

            if (pizza is null)
            {
                return NotFound($"Pizza with id {id} not found.");
            }

            return View(pizza);
        }
        public IActionResult Create()
        {
            var pizza = new Pizza()
            {
                Img = "https://picsum.photos/200/300"
            };

            return View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            using (PizzaContext ctx = new PizzaContext())
            {
                Pizza pizzaToCreate = new Pizza();
                pizzaToCreate.Name = data.Name;
                pizzaToCreate.Description = data.Description;
                pizzaToCreate.Price = data.Price;
                pizzaToCreate.Img = data.Img;

                ctx.Pizzas.Add(pizzaToCreate);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        
    }
    
}
