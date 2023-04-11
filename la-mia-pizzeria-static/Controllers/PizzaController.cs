﻿using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_static.Models;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
		private readonly ILogger<PizzaController> _logger;
		private readonly PizzaContext _context;

		public PizzaController(ILogger<PizzaController> logger, PizzaContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
        {
            var pizzas = _context.Pizzas.ToArray();

            return View(pizzas);

        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var pizza = _context.Pizzas.SingleOrDefault(p => p.Id == id);

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
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

			_context.Pizzas.Add(pizza);
			_context.SaveChanges();

			return RedirectToAction("Index");
            
        }
        
    }
}
