﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=PizzasDb;Integrated Security=True; Encrypt=False") ;
        }

        public void Seed()
        {
            if (!Pizzas.Any())
            {
                var seed = new Pizza[]
                {
            new Pizza
            {
                Img = "/img/margherita.jpg",
                Name = "Margherita",
                Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Mollitia quis est adipisci incidunt rem nostrum ipsam fuga ratione tempora eveniet!",
                Price = 5
            },
            new Pizza
            {
                Img =  "/img/brontese.png",
                Name = "Brontese",
                Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Mollitia quis est adipisci incidunt rem nostrum ipsam fuga ratione tempora eveniet!",
                Price = 13
            },
            new Pizza
            {
                Img = "/img/pizza-fritta.jpg",
                Name = "Pizza fritta",
                Description = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Mollitia quis est adipisci incidunt rem nostrum ipsam fuga ratione tempora eveniet!",
                Price = 7
            }
                };

                Pizzas.AddRange(seed);
                SaveChanges();
            }
        }
    }
}
